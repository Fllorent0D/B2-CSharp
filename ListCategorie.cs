using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProjectSchool
{
       
    [XmlRoot("CategorieList")]
    public class ListCategorie
    {

        [XmlElement("Categorie")]
        public List<Categorie> List { get; set; }

        [XmlIgnore]
        public TreeView TagTree { get; set; }
        [XmlIgnore]
        public ContextMenuStrip menuTreeCategorie {get; set; }
        [XmlIgnore]
        public ContextMenuStrip menuTreeElement { get; set; }
        [XmlIgnore]
        public ContextMenu menuTreeRoot { get; set; }
        private bool displayContextMenu = false;
       
        public ListCategorie()
        {
            List = new List<Categorie>();
        }

        #region ContextMenu
        public void setContextMenu(bool enable)
        {
            if(enable)
            {
                ContextMenuStrip menuTree = new ContextMenuStrip();
                menuTree.Opening += new CancelEventHandler(this.openContextItem);
                ToolStripMenuItem itemAjouter = new ToolStripMenuItem("Ajouter une sous-catégorie", null, new EventHandler(this.addItem));
                ToolStripMenuItem itemRenommer = new ToolStripMenuItem("Renommer", null, new EventHandler(this.renameItem));
                ToolStripMenuItem itemSupprimer = new ToolStripMenuItem("Supprimer", null, new EventHandler(this.deleteItem));

                menuTree.Items.Add(itemAjouter);
                menuTree.Items.Add(itemRenommer);
                menuTree.Items.Add(itemSupprimer);
                menuTreeCategorie = menuTree;

                menuTree = new ContextMenuStrip();
                itemSupprimer = new ToolStripMenuItem("Supprimer", null, new EventHandler(this.deleteItem));
                menuTree.Items.Add(itemSupprimer);
                menuTreeElement = menuTree;

                ContextMenu menuTreec = new ContextMenu();
                MenuItem item = new MenuItem("Ajouter une catégorie", new EventHandler(this.addItem));
                menuTreec.MenuItems.Add(item);
                menuTreeRoot = menuTreec;


                displayContextMenu = true;
            }
            else
            {
                TagTree.ContextMenu = null;
            }
        }

        private void openContextItem(object sender, CancelEventArgs e)
        {
            System.Console.WriteLine("test");
            ContextMenuStrip menu = sender as ContextMenuStrip;
            TreeNode usedNode = TagTree.GetNodeAt(TagTree.PointToClient(new Point(menu.Left, menu.Top)));
            System.Console.WriteLine();
            ToolStripMenuItem itemcat = menu.Items[0] as ToolStripMenuItem;
            ToolStripMenuItem itemsup = menu.Items[2] as ToolStripMenuItem;

            itemsup.Enabled = true;
            itemcat.Enabled = true;

            if (usedNode != null)
            {
                foreach (object obj in (usedNode.Tag as Categorie).Children)
                {
                    if (obj is Transaction)
                        itemcat.Enabled = false;
                    itemsup.Enabled = false;                
                }
            }
        }
        private void addItem(object sender, EventArgs e)
        {

            TagTree.BeginUpdate();

            Categorie newCate = new Categorie("Catégorie");
            TreeNode test = new TreeNode(newCate.Nomcategorie);
            test.Tag = newCate;


            test.ContextMenuStrip = menuTreeCategorie;

            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                ContextMenuStrip menu = item.Owner as ContextMenuStrip;
                TreeNode usedNode = TagTree.GetNodeAt(TagTree.PointToClient(new Point(menu.Left, menu.Top)));
                if (usedNode != null)
                {

                    (usedNode.Tag as Categorie).Children.Add(test.Tag as Categorie);
                    usedNode.Nodes.Add(test);

                }
                usedNode.Expand();
            }
            else
            {
                TagTree.Nodes.Add(test);
                List.Add(newCate);

            }
            test.BeginEdit();
            TagTree.EndUpdate();
        }
        private void deleteItem(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ContextMenuStrip menu = item.Owner as ContextMenuStrip;
            TreeNode usedNode = TagTree.GetNodeAt(TagTree.PointToClient(new Point(menu.Left, menu.Top)));
            if (usedNode != null)
            {
                if (usedNode.Parent != null)
                    (usedNode.Parent.Tag as Categorie).Children.Remove(usedNode.Tag);
                else
                    TagTree.Nodes.Remove(usedNode);

                usedNode.Remove();
            }
        }
        private void renameItem(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ContextMenuStrip menu = item.Owner as ContextMenuStrip;
            TreeNode usedNode = TagTree.GetNodeAt(TagTree.PointToClient(new Point(menu.Left, menu.Top)));
            if (usedNode != null)
            {
                usedNode.BeginEdit();
            }

        }
        #endregion

        #region Sauvegarder la liste
        public void Save()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (Stream fStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(ListCategorie));
                    xmlFormat.Serialize(fStream, this);
                }
            }
        }
        #endregion

        #region Création du TreeView
        public void CreateTree()
        {
            TagTree.BeginUpdate();
            foreach (Categorie node in List)
            {
                TreeNode newNode = new TreeNode(node.ToString());
                newNode.Tag = node;
                newNode.ContextMenuStrip = menuTreeCategorie;
                TagTree.Nodes.Add(newNode);

                loadSubCategories(node.Children, newNode);
            }
            TagTree.EndUpdate();
            TagTree.ExpandAll();
        }
        private void loadSubCategories(List<object> children, TreeNode parent)
        {
            foreach (object node in children)
            {
                TreeNode newNode = new TreeNode(node.ToString());
                newNode.Tag = node;

                parent.Nodes.Add(newNode);

                if (node is Categorie)
                {
                    if(displayContextMenu)
                        newNode.ContextMenuStrip = menuTreeCategorie;

                    loadSubCategories((node as Categorie).Children, newNode);
         
                }
                else
                {
                    if (displayContextMenu)
                        newNode.ContextMenuStrip = menuTreeElement;

                }
            }
        }

        public void addItem(Transaction child, TreeNode parent)
        {
            if (parent == null)
            {
                System.Console.WriteLine("Vide");
            }
            else
            {
                if (parent.Tag is Transaction)                                                //Si c'est une transaction alors on ajoute dans le parent
                    parent = parent.Parent;

                TreeNode newNode = new TreeNode(child.ToString());
                newNode.Tag = child;
                newNode.ContextMenuStrip = menuTreeElement;


                foreach (object obj in (parent.Tag as Categorie).Children)
                {
                    if (obj is Categorie)
                    {
                        MessageBox.Show("Vous ne pouvez pas placer une transaction a cote d'une categorie", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                (parent.Tag as Categorie).Children.Add(child);
                parent.Nodes.Add(newNode);
                parent.Expand();
            }
        }
        public void addItem(TreeNode child, TreeNode parent)
        {
            if (!child.Equals(parent) && !ContainsNode(child, parent))
            {
                if (parent == null)
                {
                    //Si on drop à la racine

                    if (child.Tag is Categorie) //Une catégorie à la racine = ok
                    {
                        child.ContextMenuStrip = menuTreeCategorie;

                        if (child.Parent != null)
                        {
                            bool test  = (child.Parent.Tag as Categorie).Children.Remove(child.Tag); //Retire de la liste de son parent
                            System.Console.WriteLine("remove = " + test);
                        }
                        child.Remove();

                        TagTree.Nodes.Add(child);
                        List.Add(child.Tag as Categorie);
                        updateLabels(TagTree.Nodes);
                    }
                }
                else
                {
                    //Si on drop dans un node
                    if (parent.Tag is Transaction)                                                //Si c'est une transaction alors on ajoute dans le parent
                        parent = parent.Parent;

                    if (child.Tag is Transaction)                                              //on ne peut pas avoir de transaction a cote de categorie
                    {
                        child.ContextMenuStrip = menuTreeElement;

                        foreach (object obj in (parent.Tag as Categorie).Children)
                        {
                            if (obj is Categorie)
                            {
                                MessageBox.Show("Vous ne pouvez pas placer une transaction a cote d'une categorie", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }
                    }
                    else if (child.Tag is Categorie)                                               //Idem mais inversément
                    {
                        foreach (object obj in (parent.Tag as Categorie).Children)
                        {
                            if (obj is Transaction)
                            {
                                MessageBox.Show("Vous ne pouvez pas placer une categorie a cote de transactions", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }
                    }
                    if (child.Parent != null)
                    {
                        if (parent == child.Parent)                                        //draggedNode n'a pas bougé
                            return;

                        (child.Parent.Tag as Categorie).Children.Remove(child.Tag);     //Retirer une catégorie qui n'est pas la racine
                    }
                    else
                        List.Remove(child.Tag as Categorie);               //Retirer une catégorie qui est à la racine



                    (parent.Tag as Categorie).Children.Add(child.Tag);                  //Mettre à jour la liste d'enfant dans la catégorie

                    child.Remove();                                                       //Mettre à jour la treeview
                    parent.Nodes.Add(child);
                    parent.Expand();

                }
            }
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {

            if (node2 == null || node2.Parent == null)
                return false;
            if (node2.Parent.Equals(node1))
                return true;


            return ContainsNode(node1, node2.Parent);
        }
        #endregion

        #region Clonage de la liste
        public void Clone(ListCategorie listToFill)
        {
            listToFill.List = new List<Categorie>();
            foreach (Categorie item in this.List)
            {
                Categorie newCategorie = new Categorie(item.Nomcategorie);
                listToFill.List.Add(newCategorie);
                CloneChildren(item.Children, newCategorie.Children);

            }
        }
        private void CloneChildren(List<object> children, List<object> newParent)
        {
            foreach (object node in children)
            {
                IBilan newItem;
                if(node is Transaction)
                {
                    Transaction item = node as Transaction;
                    newItem = new Transaction(item.Contrepartie, item.Type, item.DateTransaction, item.Somme);
                }
                else
                {
                    Categorie item = node as Categorie;
                    newItem = new Categorie(item.Nomcategorie);
                    CloneChildren(item.Children, (newItem as Categorie).Children);
                }
                newParent.Add(newItem);
            }
        }
        #endregion

        #region Filtre de la liste
        public void filter(int year, int month, int type)
        {
            foreach(Categorie item in List)
            {
                filterChildren(year, month, type, item);
            }
        }
        private void filterChildren(int year, int month,int type, Categorie parent)
        {
            List<object> toremove = new List<object>();
            foreach(object item in parent.Children)
            {
                if(item is Transaction)
                {
                    Transaction test = item as Transaction;

                    if ((month != 0 && test.DateTransaction.Month != month) || (year != 0 && (test.DateTransaction.Year + 2000) != year) || (type == 1 && test.Somme > 0) || (type == 2 && test.Somme < 0))
                    {
                        toremove.Add(item);
                    }
                   
                   

                }
                else if(item is Categorie)
                {
                    filterChildren(year, month,type, item as Categorie);
                }
            }
            foreach(object item in toremove)
            {
                parent.Children.Remove(item);
            }
        }
        #endregion

        public void updateLabels(TreeNodeCollection tn)
        {
            foreach (TreeNode item in tn)
            {
                //System.Console.WriteLine(item.Text);
                item.Text = item.Tag.ToString();
                updateLabels(item.Nodes);
            }
        }
    }
}

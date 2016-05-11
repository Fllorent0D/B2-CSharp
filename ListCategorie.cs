using System;
using System.Collections.Generic;
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

        public ListCategorie()
        {
            List = new List<Categorie>();

        }

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


        public void CreateTree()
        {
            TagTree.BeginUpdate();
            foreach (Categorie node in List)
            {
                TreeNode newNode = new TreeNode(node.ToString());
                newNode.Tag = node;
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
                    loadSubCategories((node as Categorie).Children, newNode);
            }
        }
        #region Clonage de la liste
        public void Clone(ListCategorie listToFill)
        {
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
        public void filter(int year, int month)
        {
            foreach(Categorie item in List)
            {
                filterChildren(year, month, item);
            }
        }
        private void filterChildren(int year, int month, Categorie parent)
        {
            foreach(object item in parent.Children)
            {
                if(item is Transaction)
                {
                    Transaction test = item as Transaction;

                    if((month != 0 && test.DateTransaction.Month != month) || (year != 0 && test.DateTransaction.Year != year))
                    {
                        parent.Children.Remove(item);
                    }
                    
                }
                else if(item is Categorie)
                {
                    filterChildren(year, month, item as Categorie);
                }
            }

        }
        #endregion

    }
}

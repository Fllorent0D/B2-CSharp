using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProjectSchool
{
    public partial class Form1 : Form
    {
        private BindingList<Transaction> achats;
        private ListCategorie listeCategorie;
        private ListCategorie listeBilan;
        public ContextMenuStrip menuTree;
        public Form1()
        {
            InitializeComponent();


            listeCategorie = new ListCategorie();
            listeCategorie.TagTree = achatTreeView;
            listeCategorie.setContextMenu(true);
            System.Console.WriteLine(listeCategorie.TagTree.ContextMenu);
            

            listeBilan = new ListCategorie();
            listeBilan.TagTree = achatTreeView;
            listeBilan.setContextMenu(false);

            //Binding avec le datagrid view
            achats = new BindingList<Transaction>();
            BindingSource source = new BindingSource(achats, null);
            achatGridView.DataSource = source;

                     
            
            //DateTimePicker dateFilter = new DateTimePicker();
            dateFilter.Format = DateTimePickerFormat.Custom;
            dateFilter.ShowUpDown = true; // to prevent the calendar from being displayed

            //Init components
            modeBox.SelectedIndex = 0;
            triCombo.SelectedIndex = 0;

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        

        private void chargerDesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Parser
            OpenFileDialog fichier = new OpenFileDialog();
            fichier.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            if (fichier.ShowDialog() == DialogResult.OK)
            {
                TextFieldParser parser = new TextFieldParser(fichier.FileName);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        string[] rows = field.Split(default(char), ';');
                        string[] date = rows[2].Split(default(char), '-');

                        Transaction nouvMontant = new Transaction(rows[0], rows[1], new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), Convert.ToDouble(rows[3]));
                        System.Console.WriteLine(nouvMontant);
                        achats.Add(nouvMontant);
                    }
                }

            }
        }

        private void achatGridView_MouseDown(object sender, MouseEventArgs e)
        {
            //Clique droit sur tuple
            
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = achatGridView.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    Transaction view = (Transaction)achatGridView.Rows[info.RowIndex].DataBoundItem;
                    if (view != null)
                    {
                        achatGridView.DoDragDrop(view, DragDropEffects.Copy);
                    }

                }
            }
        }

        private void achatTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if(modeBox.SelectedIndex == 0)
            {
                e.Effect = DragDropEffects.Copy;
                e.Effect = e.AllowedEffect;

            }
            
        }

        private void achatTreeView_DragDrop(object sender, DragEventArgs e)
        {
            Point p = achatTreeView.PointToClient(new Point(e.X, e.Y));
            TreeNode nodeUsed = (TreeNode)achatTreeView.GetNodeAt(p);

            //Si c'est un Montant, vue de gauche

            if (e.Data.GetDataPresent(typeof(Transaction)))
            {
                Transaction child = (Transaction)e.Data.GetData(typeof(Transaction));
                listeCategorie.addItem(child, nodeUsed);

            }
            else if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode child = (TreeNode)e.Data.GetData(typeof(TreeNode));
                listeCategorie.addItem(child, nodeUsed);
            }
            listeCategorie.updateLabels(listeCategorie.TagTree.Nodes);

        
        }

        private void sauvegarderDesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeCategorie.Save();
        }

        private void achatTreeView_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = achatTreeView.PointToClient(new Point(e.X, e.Y));
            TreeNode usedNode = (TreeNode)achatTreeView.GetNodeAt(targetPoint);

            if (usedNode == null)
                return;

            if (usedNode.Tag is Categorie)
            {
                achatTreeView.SelectedNode = usedNode;
            }
            else if (usedNode.Tag is Transaction)
            {
                achatTreeView.SelectedNode = usedNode.Parent;
            }


        }

        private void achatTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void chargerDesDonnéesDéjàImputéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichier = new OpenFileDialog();
            fichier.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            if (fichier.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ListCategorie));
                using (Stream fStream = File.OpenRead(fichier.FileName))
                {
                    listeCategorie = (ListCategorie)xmlFormat.Deserialize(fStream);
                    achatTreeView.Nodes.Clear();
                    listeCategorie.TagTree = achatTreeView;
                    listeCategorie.setContextMenu(true);

                    //listeCategorie.menuTree = menuTree;
                    listeCategorie.CreateTree();
                }
            }
        }



        private void achatTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            System.Console.WriteLine(sender);
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
              
            }
        }

        private void achatTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            System.Console.WriteLine(e.Label);
            
            if (e.Label == null || e.Label.Length <= 0)
            {
                e.CancelEdit = true;
            }
            else
            {
                e.Node.EndEdit(false);
                (e.Node.Tag as Categorie).Nomcategorie = e.Label;

                e.CancelEdit = true;

                e.Node.Text = e.Node.Tag.ToString();


            }
            System.Console.WriteLine(e.Node.Tag);
        }
        //Change l'affichage pour le mode
        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(modeBox.SelectedIndex == 1)
            {
                groupFilter.Visible = true;
                typeFilter.SelectedIndex = 0;
                updateFilter();
                statusBar.BackColor = Color.OrangeRed;
                statusLabel.Text = "Bilan";
                achatGridView.Enabled = false;
                foreach (DataGridViewRow row in achatGridView.Rows)
                    row.DefaultCellStyle.BackColor = Color.LightGray;
               

            }
            else
            {
                achatGridView.Enabled = true;
                foreach (DataGridViewRow row in achatGridView.Rows)
                  row.DefaultCellStyle.BackColor = Color.White;
                    
                groupFilter.Visible = false;
                achatTreeView.Nodes.Clear();
                listeCategorie.CreateTree();
                statusBar.BackColor = SystemColors.MenuHighlight;
                statusLabel.Text = "Edition";

            }
        }

        private void triCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(triCombo.SelectedIndex)
            {
                case 0:
                    dateFilter.CustomFormat = " ";
                    dateFilter.Enabled = false;

                    break;
                case 1:
                    dateFilter.CustomFormat = "yyyy";
                    dateFilter.Enabled = true;

                    break;
                case 2:
                    dateFilter.CustomFormat = "MMMM yyyy";
                    dateFilter.Enabled = true;

                    break;
            }
            updateFilter();
        }
        public void updateFilter()
        {
            int year = 0;
            int month = 0;
            int type = 0;
            switch (triCombo.SelectedIndex)
            {
                case 2:
                    month = dateFilter.Value.Date.Month;
                    year = dateFilter.Value.Date.Year;

                    break;
                case 1:
                    year = dateFilter.Value.Date.Year;
                    
                    break;
            }
            switch(typeFilter.SelectedIndex)
            {
                case 1:
                    type = 1; //-
                    break;
                case 2:
                    type = 2; //+
                    break;

            }
            listeCategorie.Clone(listeBilan);
            achatTreeView.Nodes.Clear();
            listeBilan.filter(year, month, type);
            listeBilan.setContextMenu(false);
            listeBilan.CreateTree();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Categorie nouvelle = new Categorie();
            TreeNode nouvellet = new TreeNode();
            listeCategorie.List.Add(nouvelle);
            nouvellet.Tag = nouvelle;
            listeCategorie.addItem(nouvellet, null);
            //listeCategorie.CreateTree();

            nouvellet.BeginEdit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            achatTreeView.Nodes.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            achatTreeView.Nodes.Clear();
            listeCategorie.CreateTree();
        }

        private void dateFilter_FormatChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        private void dateFilter_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void dateFilter_ValueChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void typeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilter();
        }
    }
}

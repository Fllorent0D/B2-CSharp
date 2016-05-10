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

    }
}

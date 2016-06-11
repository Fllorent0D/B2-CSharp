using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectSchool
{
    [Serializable]
    [XmlInclude(typeof(Transaction)), XmlInclude(typeof(Categorie))]
    public class Categorie : IBilan
    {
        public Categorie()
        {
            Children = new List<object>();
            
        }
        public Categorie(string v)
        {
            Nomcategorie = v;
            Children = new List<object>();
        }

        public String Nomcategorie { get; set; }

        [XmlArray("Categorie_Obj_List"), XmlArrayItem(typeof(object), ElementName = "Cat_Elem")]
        public List<object> Children { get; set; }


        public double getSum()
        {
            double val = 0;
            foreach(object item in Children)
            {
                val += (item as IBilan).getSum();
            }
            return val;
        }
        public override string ToString()
        {
            return Nomcategorie + " | " +getSum()+" €";
        }
    }
}

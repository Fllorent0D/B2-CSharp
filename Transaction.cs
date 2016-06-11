using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchool
{
    [Serializable]
    public class Transaction : IBilan
    {
        public string Contrepartie { get; set; }
        public string Type { get; set; }
        public DateTime DateTransaction { get; set; }
        public double Somme { get; set; }

        public Transaction(string v1, string v2, DateTime dateTime, double v3)
        {
            this.Contrepartie = v1;
            this.Type = v2;
            this.DateTransaction = dateTime;
            this.Somme = v3;
        }
        public Transaction()
        {

        }
        public double getSum()
        {
            return Somme;
        }
        public override string ToString()
        {
            return Contrepartie + " | " + Somme +" €";
        }
    }
}

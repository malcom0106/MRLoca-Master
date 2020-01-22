using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class DataDDL
    {
        public string Value { set; get; }
        public string Affichage { set; get; }

        public DataDDL()
        {

        }
        public DataDDL(string value, string affichage)
        {
            Value = value;
            Affichage = affichage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class Adresse
    {
        public int IdAdresse { get; set; }
        public string Nom { get; set; }
        public string Numero { get; set; }
        public string Voie { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        //public bool Statut { get; set; }
        public Adresse()
        {

        }
        public Adresse(int idAdresse, string nom, string numero, string voie, string codePostal, string ville)
        {
            IdAdresse = idAdresse;
            Nom = nom;
            Numero = numero;
            Voie = voie;
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}
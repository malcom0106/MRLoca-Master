using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class Avis
    {
        public int IdClient { set; get; }
        public Client Client { set; get; }
        public int IdHebergement { set; get; }
        public Hebergement Hebergement { set; get; }
        public int Note { set; get; }
        public string Commentaire { set; get; }
        public bool Statut { set; get; }
        public DateTime Date { set; get; }
        public Avis()
        {

        }
    }
}
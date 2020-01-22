using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class Commande
    {
        public int IdReservation { get; set; }
        public  Client Locataire { get; set; }
        public Hebergement Location { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string PrixTotal { get; set; }
        public bool Statut { get; set; }
        public int ModePaiement { get; set; }
        public Commande()
        {

        }
        public Commande(int idreservation, Client locataire, Hebergement location, DateTime datedebut, DateTime datefin, string prixtotal, bool statut, int modepaiement)
        {
            IdReservation = idreservation;
            Locataire = locataire;
            Location = location;
            DateDebut = datedebut;
            DateFin = datefin;
            PrixTotal = prixtotal;
            Statut = statut;
            ModePaiement = modepaiement;
    }
    }
}
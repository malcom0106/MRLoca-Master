using MRLoca.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class Message
    {
        public int IdMessagerie { get; set; }
        public int IdExpediteur { get; set; }
        public int IdDestinataire { get; set; }
        public string Sujet { get; set; }
        public string LeMessage { get; set; }
        public DateTime DateMessage { get; set; }
        public bool Statut { get; set; }
        public Client Expediteur { get; set; }
        public Client Destinataire { get; set; }
        public Hebergement Logement { get; set; }
        public Message() 
        {
        }
        public Message(int idmessagerie, int idexpediteur, int iddestinataire, string lemessage, DateTime datemessage, bool statut)
        {
            
            IdMessagerie = idmessagerie;
            IdExpediteur = idexpediteur;
            IdDestinataire = iddestinataire;
            LeMessage = lemessage;
            DateMessage = datemessage;
            Statut = statut;
        }
        public Message(int idmessagerie, int idexpediteur, int iddestinataire, string lemessage, DateTime datemessage, bool statut, Client expediteur, Client destinataire, Hebergement hebergement, string sujet)
        {
            IdMessagerie = idmessagerie;
            IdExpediteur = idexpediteur;
            IdDestinataire = iddestinataire;
            LeMessage = lemessage;
            DateMessage = datemessage;
            Statut = statut;
            Expediteur = expediteur;
            Destinataire = destinataire;
            Logement = hebergement;
            Sujet = sujet;
        }
    }
}
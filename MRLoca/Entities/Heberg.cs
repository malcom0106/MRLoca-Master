using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class Heberg
	{
		public int IdHebergement { set; get; }
		public string Photo { set; get; }
		public string Nom { set; get; }
		public string Type { set; get; }
		public string Description { set; get; }
        public int IdClient { set; get; }
        public int IdAdresse { set; get; }


        public Heberg()
		{
		}
		public Heberg(int idHebergement,string photo, string nom, string type, string description, int idClient, int idAdresse)
		{
			IdHebergement = idHebergement;
			Photo = photo;
			Nom = nom;			
			Type = type;			
			Description = description;
            IdClient = idClient;
            IdAdresse = idAdresse;

        }
		 

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
	public class Client
	{
        public int IdClient { set; get; }
		public string Nom {set; get;}
		public string Prenom { set; get; }
        public string Email { set; get; }
        public string Telephone { set; get; }
        public bool Type { set; get; }
        public string Login { set; get; }
		public string Password { set; get; }
        public List<Adresse> Adresses { set; get; }

		public Client()
		{

		}
		public Client(int idClient , string nom, string prenom, string login, string password, string email, string telephone, bool type, List<Adresse> adresses)
		{
            IdClient = idClient; 
            Nom = nom;
			Prenom = prenom;			
			Telephone = telephone;
			Login = login;
			Password = password;
            Adresses = adresses;
            Email = email;
            Type = type;
        }
	}
}
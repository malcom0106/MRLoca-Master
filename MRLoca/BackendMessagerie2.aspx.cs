using MRLoca.Dao;
using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class BackendMessagerie2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Client Utilisateur = null;
            if (Session["Client"] != null)
            {
                Utilisateur = new Client();
                Utilisateur = (Client)Session["Client"];
            }
            DaoMessage daoMessage = new DaoMessage();
            List<Message> listeMessages = daoMessage.GetMessageClient(Utilisateur.IdClient);
            List<SujetMessagerie> listesujets = (from l in listeMessages
                              where l.IdDestinataire != Utilisateur.IdClient || l.IdExpediteur != Utilisateur.IdClient
                                                 group l by new
                              {
                                  l.Logement.IdHebergement,
                                  l.IdDestinataire,
                                  l.IdExpediteur
                              }
                              into g
                              select new SujetMessagerie()
                              {
                                  IdHebergement = g.Key.IdHebergement,
                                  IdDestinataire = g.Key.IdDestinataire,
                                  IdExpediteur = g.Key.IdExpediteur
                              }).ToList();
            

            this.GridView1.DataSource = listesujets.OrderBy(l => l.IdHebergement);
            this.GridView1.DataBind();
            //this.lvwSujet.DataSource = listesujets;
            //this.lvwSujet.DataBind();
        }

        protected void lbtDiscution_Click(object sender, EventArgs e)
        {

        }
    }
}
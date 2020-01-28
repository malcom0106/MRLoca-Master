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
            List<Message> ListeMessages = daoMessage.GetMessageClient(Utilisateur.IdClient);


            this.ListView1.DataSource =  ;
            this.ListView1.DataBind();
        }

        protected void lbtDiscution_Click(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class BackendCommandes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                DaoReservation daoreservation = new DaoReservation();
                this.lvwHebergement.DataSource = daoreservation.GetCommande(Utilisateur.IdClient);
                this.lvwHebergement.DataBind();
            }
            catch (Exception ex) 
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnContact_Click(object sender, EventArgs e)
        {

        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {

        }

        protected void btnAvis_Click(object sender, EventArgs e)
        {

        }
    }
}
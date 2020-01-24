using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class backend : System.Web.UI.MasterPage
    {
        //Variable Global Utilisable ensuite dans les page qui utilise cete master page en utilisant le code suivant 
        // backend maPageBackEnd = (backend)Page.Master;
        // maPageBackEnd.Utilisateur = (Client) Session["Client"];

        public Client Utilisateur { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilisateur = null;
            if (Session["Client"] == null)
            {
                this.lnklogin.Visible = true;
                this.btnLonout.Visible = false;
            }
            else
            {
                Utilisateur = (Client)Session["Client"];
                this.lblClient.Text = "Bonjour, " + Utilisateur.Nom + " " + Utilisateur.Prenom+' ';
                this.lnklogin.Visible = false;
                this.btnLonout.Visible = true;
            }
            if(Utilisateur == null)
            {
                Response.Redirect("connection.aspx");
            }


            if (Session["Reservation"] == null)
            {
                this.lnkConnect.Visible = false;
            }
            else
            {
                this.lnkConnect.Visible = true;
            }
        }
        public void AddError(Exception ex)
        {
            Functions.AddError(ex);
            this.lblerrormaster.Text = ex.Message;
        }
        protected void btnLonout_Click(object sender, EventArgs e)
        {

            Response.Redirect("deconnection.aspx");
        }
    }
}
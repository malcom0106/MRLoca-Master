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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Client Utilisateur = null;
            if (Session["Client"] != null)
            {
                Utilisateur = (Client)Session["Client"];
            }
            if (Utilisateur == null) { 
                this.lnklogin.Visible = true;
                this.btnLonout.Visible = false;
            }
            else
            {               
                this.lnklogin.Visible = false;
                this.btnLonout.Visible = true;
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
            this.lblErrorMaster.Text = ex.Message;
            Functions.AddError(ex);

        }

        protected void btnLonout_Click(object sender, EventArgs e)
        {
            Response.Redirect("deconnection.aspx");
        }
    }
}
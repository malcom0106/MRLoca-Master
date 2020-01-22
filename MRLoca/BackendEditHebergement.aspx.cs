using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class BackendEditHebergement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IdHebergement"] != null && Request.QueryString["IdHebergement"] != "")
            {
                this.lblTest.Text = "Id Hebergement = " + Request.QueryString["IdHebergement"];
            } 
            else
            {
                Response.Redirect("BackendHebergement.aspx");
            }
        }
    }
}
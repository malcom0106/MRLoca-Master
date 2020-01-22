using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class Reservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ListeHebergement"] != null && Session["Reservation"] != null)
                {
                    if (Session["Client"] == null)
                    {
                        Response.Redirect("connection.aspx?msg=reservation");
                    }
                    else
                    {
                        Response.Redirect("Paiement.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
        }
    }
}
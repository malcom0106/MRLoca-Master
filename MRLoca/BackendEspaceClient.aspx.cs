using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class BackendEspaceClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                    if (Utilisateur.Type)
                    {
                        this.panProprio.Visible = true;
                    }
                    else
                    {
                        this.panProprio.Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
                         
        }
    }
}
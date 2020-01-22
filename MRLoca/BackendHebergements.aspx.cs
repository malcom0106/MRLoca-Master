using MRLoca.Dao;
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
    public partial class BackendHebergements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Client Utilisateur = null;
                    if (Session["Client"] != null)
                    {
                        Utilisateur = (Client)Session["Client"];
                    }
                    DaoHebergement doaHebergement = new DaoHebergement();
                    this.lvwHebergement.DataSource = doaHebergement.GetHebergementProprietaire(Utilisateur.IdClient);
                    this.lvwHebergement.DataBind();
                }                
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string idHebergement = ((Button)sender).CommandArgument;
                Response.Redirect("BackendEditHebergement.aspx?IdHebergement=" + idHebergement);
            } 
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnNouveauLgt_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BackendNouvelHebergement.aspx");
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }
    }
}
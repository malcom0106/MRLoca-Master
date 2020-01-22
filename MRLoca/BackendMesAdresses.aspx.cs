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
    public partial class BackendMesAdresses : System.Web.UI.Page
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

                    DaoAdresse daoAdresse = new DaoAdresse();
                    this.lstAdresse.DataSource = daoAdresse.GetAdresseClient(Utilisateur.IdClient);
                    this.lstAdresse.DataBind();
                }
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnsupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                //Recuperation de l'idAdresse
                int IdAdresse = Convert.ToInt32(((Button)sender).CommandArgument);

                //Modification  l'adresse
                DaoAdresse daoAdresse = new DaoAdresse();
                daoAdresse.DelAdresse(IdAdresse);
                //daoAdresse.UpdateAdresse(IdAdresse);
                //Recharger la liste des adresses
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                this.lstAdresse.DataSource = daoAdresse.GetAdresseClient(Utilisateur.IdClient);
                this.lstAdresse.DataBind();
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            //Recuperation de l'idAdresse
            string IdAdresse = Convert.ToString(((Button)sender).CommandArgument);
            //Redirection vers la page modifier
            Response.Redirect("BackendEditAdresse.aspx?IdAdresse=" + IdAdresse);
        }
    }
}
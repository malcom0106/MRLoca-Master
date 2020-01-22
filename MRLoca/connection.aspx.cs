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
    public partial class connection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["Client"] = null;
                    if (Request.QueryString["msg"] != null || Request.QueryString["msg"] != "")
                    {
                        if (Request.QueryString["msg"] == "favori")
                        {
                            this.lblMsg.Text = "Merci de vous connecter afin d'accéder à vos favoris";
                        }
                        else if (Request.QueryString["msg"] == "espaceclient")
                        {
                            this.lblMsg.Text = "Merci de vous connecter afin d'accéder à votre espace client";
                        }
                        else if (Request.QueryString["msg"] == "reservation")
                        {
                            this.lblMsg.Text = "Merci de vous connecter afin d'accéder au paiement votre commande";
                        }
                        this.lblMsg.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
            
        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                string email = this.txtEmail.Text;
                string password = this.txtPassword.Text;
                DaoClient DaoUtilisateur = new DaoClient();
                Client Utilisateur = DaoUtilisateur.GetUtilisateur(email, password);

                if (Utilisateur != null)
                {
                    Session["Client"] = Utilisateur;
                    if (Session["Reservation"] != null)
                    {
                        Response.Redirect("Paiement.aspx");
                    }
                    else
                    {
                        Response.Redirect("BackendEspaceClient.aspx");
                    }
                }
                else
                {
                    this.lblClient.Visible = true;
                }
            }
            catch(Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
                     
        }
    }
}
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
    public partial class Favoris : System.Web.UI.Page
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
                    if (Utilisateur != null)
                    {
                        if (Session["ListeHebergement"] != null)
                        {
                            DaoFavori daoFavori = new DaoFavori();
                            List<Hebergement> ListeFavoris = daoFavori.GetFavoris(Utilisateur.IdClient);
                            if (ListeFavoris.Count > 0)
                            {
                                this.gvwFavoris.DataSource = ListeFavoris;
                                this.gvwFavoris.DataBind();
                            }
                            else
                            {
                                this.pnlModal.Visible = true;
                            }
                        }
                        else
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("connection.aspx?msg=favori");
                    }
                }
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSuppr = Convert.ToInt32(((Button)sender).CommandArgument);
                DaoFavori daoFavori = new DaoFavori();
                Client Utilisateur = (Client)Session["Client"];

                daoFavori.DelFavori(Utilisateur.IdClient, IdSuppr);

                this.gvwFavoris.DataSource = daoFavori.GetFavoris(Utilisateur.IdClient);
                this.gvwFavoris.DataBind();
                Response.Redirect("Favoris.aspx");
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(((Button)sender).CommandArgument);
                Session["Reservation"] = Id;
                Response.Redirect("Reservations.aspx");
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }
    }
}
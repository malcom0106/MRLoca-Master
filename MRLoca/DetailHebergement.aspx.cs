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
    public partial class DetailHebergement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ListeHebergement"] != null)
                    {
                        if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            Session["IdHebergement"] = Convert.ToInt32(Request.QueryString["id"]);
                        }
                        if (Session["IdHebergement"] != null)
                        {
                            //On utilise la DAO Hebergement pour recupere un logement dont l'Id est stocké en session
                            DaoHebergement daoHebergement = new DaoHebergement();
                            int IdHebergement = (int)Session["IdHebergement"];
                            Hebergement MaSelection = daoHebergement.GetHebergement(IdHebergement);

                            this.imgHebergement.ImageUrl = MaSelection.Photo;
                            this.lblTitre.Text = MaSelection.Nom;
                            this.lblDescription.Text = MaSelection.Description;
                            Adresse AdresseLgt = MaSelection.Adresse;

                            this.lblAdresse.Text = AdresseLgt.Numero + " " + AdresseLgt.Voie + "<br />" + AdresseLgt.CodePostal + " " + AdresseLgt.Ville;
                            this.lblPrix.Text = Convert.ToString(MaSelection.PrixDeBase);
                            this.btnFavori.CommandArgument = Convert.ToString(MaSelection.IdHebergement);
                            this.btnReserve.CommandArgument = Convert.ToString(MaSelection.IdHebergement);
                        }
                        else
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
        }

        protected void btnFavori_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Client"] != null)
                {
                    int Id = Convert.ToInt32(((Button)sender).CommandArgument);
                    DaoFavori daoFavori = new DaoFavori();
                    Client Utilisateur = (Client)Session["Client"];
                    List<Hebergement> mesfavoris = daoFavori.GetFavoris(Utilisateur.IdClient);
                    if (mesfavoris != null)
                    {
                        bool existe = false;
                        foreach (Hebergement item in mesfavoris)
                        {
                            if (item.IdHebergement == Id)
                            {
                                existe = true;
                                break;
                            }
                        }
                        if (existe)
                        {
                            daoFavori.AddFavori(Utilisateur.IdClient, Id);
                        }
                    }
                    else
                    {
                        daoFavori.AddFavori(Utilisateur.IdClient, Id);
                    }
                    Response.Redirect("Favoris.aspx");
                }
                else
                {
                    Response.Redirect("Connection.aspx?msg=favori");
                }
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
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
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
        }
    }
}
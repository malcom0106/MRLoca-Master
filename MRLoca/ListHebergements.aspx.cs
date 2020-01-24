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
    public partial class ListHebergements : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Client Utilisateur = null;
            if (Session["Client"] != null)
            {
                Utilisateur = (Client)Session["Client"];
            }
            if (Utilisateur != null)
            {
                Page.MasterPageFile = "backend.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ListeHebergement"] != null)
                    {
                        if (Session["Recherche"] != null)
                        {
                            Dictionary<string, string> dict = (Dictionary<string, string>)Session["Recherche"];
                            string dep = dict["departement"];
                            string type = dict["type"];

                            List<Hebergement> ListeRecherche = LoadHebergementrecherche((Dictionary<string, string>)Session["Recherche"]);
                            if (ListeRecherche != null)
                            {
                                this.litTitre.Text = @"Liste des Hebergements Recherchés ";
                                this.lsvHebergement.DataSource = ListeRecherche;
                                this.lsvHebergement.DataBind();
                            }
                            else
                            {
                                this.pnlModal.Visible = true;
                            }

                        }
                        else
                        {
                            this.litTitre.Text = @"Liste des Hebergements";
                            this.lsvHebergement.DataSource = Session["ListeHebergement"];
                            this.lsvHebergement.DataBind();
                        }


                    }
                    else
                    {
                        Response.Redirect("default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }            
        }
        private List<Hebergement> LoadHebergementrecherche(Dictionary<string,string> dict)
        {
            List<Hebergement> herb = null; 
            try
            {
                DaoHebergement Daohebergement = new DaoHebergement();
                herb = Daohebergement.GetHebergementRecherche(dict);
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
            return herb;
        }

        protected void lsvHebergement_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                List<Hebergement> ListeHebergement = null;
                if (Session["Recherche"] != null)
                {
                    Dictionary<string, string> dict = (Dictionary<string, string>)Session["Recherche"];
                    string dep = dict["departement"];
                    string type = dict["type"];
                    ListeHebergement = LoadHebergementrecherche((Dictionary<string, string>)Session["Recherche"]);
                }
                else
                {
                    ListeHebergement = (List<Hebergement>)Session["ListeHebergement"];
                }
                this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                this.lsvHebergement.DataSource = ListeHebergement;
                this.lsvHebergement.DataBind();
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
                        if (!existe)
                        {
                            daoFavori.AddFavori(Utilisateur.IdClient, Id);
                        }
                    }
                    else
                    {
                        daoFavori.AddFavori(Utilisateur.IdClient, Id);
                    }
                    Response.Redirect("Favoris.aspx",false);
                }
                else
                {
                    Response.Redirect("Connection.aspx?msg=favori",false);
                }
            }
            catch (Exception ex)
            {
                Functions.AddError(ex);
            }
        }

        protected void btnreserve_Click(object sender, EventArgs e)
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
     
        protected void lbtDetail_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                Session["IdHebergement"] = Id;
                Response.Redirect("DetailHebergement.aspx");
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }            
        }

        protected void lnkTousLgt_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Recherche"] = null;
                Response.Redirect("ListHebergements.aspx");
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }            
        }
    }
}
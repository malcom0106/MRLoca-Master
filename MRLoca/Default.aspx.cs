using MRLoca.Dao;
using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["ListeHebergement"] = Functions.LoadHebergement();
                if (!IsPostBack)
                {
                    //Nombre de photo dans le carrousel 
                    int nbrephotos = 5;
                    List<Hebergement> ListeHasardeuse = lgthasard(nbrephotos);
                    this.litCarousel.Visible = true;
                    this.litCarousel.Text = Functions.GenerationCarousel(ListeHasardeuse);

                    DaoDataDDL dataDDL = new DaoDataDDL();
                    this.ddlDepartement = Functions.GenerationDDL(this.ddlDepartement, dataDDL.GetDataDDL("Departement_code", "Departement_nom_uppercase", "Departement", null, null));
                    this.ddlDepartement.DataBind();

                    this.ddlType = Functions.GenerationDDL(this.ddlType, dataDDL.GetDataDDL("IdTypeLgt", "NomLgt", "TypeLgt", null, null));
                    this.ddlType.DataBind();
                }
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
                       
        }
        private List<Hebergement> lgthasard (int NbrHebergement)
        {
            List<Hebergement> listeHasardeuse = new List<Hebergement>();
            try
            {
                List<Hebergement> listeHebergement = new List<Hebergement>();
                listeHebergement = (List<Hebergement>)Session["ListeHebergement"];
                
                Random rnd = new Random();
                List<int> listeInt = new List<int>();
                for (int i = 0; i <= NbrHebergement - 1; i++)
                {
                    int id = rnd.Next(1, listeHebergement.Count());
                    while (listeInt.Contains(id))
                    {
                        id = rnd.Next(0, listeHebergement.Count());
                    }
                    listeInt.Add(id);
                    Hebergement lgt = listeHebergement[id];
                    listeHasardeuse.Add(lgt);
                }
                listeInt.Clear();
                
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
            return listeHasardeuse;
        }

        protected void btnValidation_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> dictionnaireRecherche = new Dictionary<string, string>();
                dictionnaireRecherche.Add("departement", this.ddlDepartement.SelectedValue);
                dictionnaireRecherche.Add("type", this.ddlType.SelectedValue);
                Session["Recherche"] = dictionnaireRecherche;
                Response.Redirect("ListHebergements.aspx");
            }
            catch (Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
        }
    }
}
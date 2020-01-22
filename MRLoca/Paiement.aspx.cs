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
    public partial class Paiement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Client"] != null && Session["Reservation"] != null)
                {
                    //Selection du logement à reserver
                    Hebergement MaResa;
                    DaoHebergement daoHebergement = new DaoHebergement();
                    MaResa = daoHebergement.GetHebergement((int)Session["Reservation"]);
                    this.imgHebergement.ImageUrl = MaResa.Photo;
                    this.lblTitre.Text = MaResa.Nom;
                    this.lblDescription.Text = MaResa.Description;
                    Adresse adresseHebergement = MaResa.Adresse;
                    this.lblAdresse.Text = Convert.ToString(adresseHebergement.Numero) + ' ' + Convert.ToString(adresseHebergement.Voie) + "<br />" + Convert.ToString(adresseHebergement.CodePostal) + " " + Convert.ToString(adresseHebergement.Ville);
                    //this.lblPrix.Text = Convert.ToString(MaResa.Prix);
                    DaoDataDDL daoData = new DaoDataDDL();
                    this.ddlPaiement = Functions.GenerationDDL(this.ddlPaiement, daoData.GetDataDDL("IdModePaiement", "NomModePaiement", "ModePaiement", null, null));
                    this.ddlPaiement.DataBind();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch(Exception ex)
            {
                ((SiteMaster)Page.Master).AddError(ex);
            }            
        }

        protected void btnPayer_Click(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = (Client)Session["Client"];

                int idclient = Convert.ToInt32(Utilisateur.IdClient);
                int idhebergement = Convert.ToInt32(Session["Reservation"]);
                DateTime datedebut = Convert.ToDateTime(this.txtDateDebut.Text);
                DateTime datefin = Convert.ToDateTime(this.txtDateFin.Text);
                string Prix = "100";
                bool Statut = true;
                int ModePaiement = 0;
                if (this.ddlPaiement.SelectedValue!= null)
                {
                    ModePaiement = 1;
                }
                else
                {
                    ModePaiement = Convert.ToInt32(this.ddlPaiement.SelectedValue);
                }
                
                DaoReservation daoReservation = new DaoReservation();

                daoReservation.SetReservation(idclient, idhebergement, datedebut, datefin, Prix, Statut, ModePaiement);
                Response.Redirect("BackendCommandes.aspx");
                
            }
            catch(Exception ex)
            {
                this.lblErreur.Visible = true;
                this.lblErreur.Text = ex.Message;
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
        }
    }
}
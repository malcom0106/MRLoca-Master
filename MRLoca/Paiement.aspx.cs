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
                    this.txtaujourdhui.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    this.imgHebergement.ImageUrl = MaResa.Photo;
                    this.lblTitre.Text = MaResa.Nom;
                    this.lblDescription.Text = MaResa.Description;
                    Adresse adresseHebergement = MaResa.Adresse;
                    if (adresseHebergement != null)
                    {
                        this.lblAdresse.Text = Convert.ToString(adresseHebergement.Numero) + ' ' + Convert.ToString(adresseHebergement.Voie) + "<br />" + Convert.ToString(adresseHebergement.CodePostal) + " " + Convert.ToString(adresseHebergement.Ville);
                    }
                    if (!IsPostBack)
                    {
                        this.lblPrix.Text = Convert.ToString(MaResa.PrixDeBase);
                        this.lblDuree.Text = "1";
                    }
                    else
                    {
                        int compteJour = Convert.ToInt32(((Convert.ToDateTime(this.txtDateFin.Text)).Subtract(Convert.ToDateTime(this.txtDateDebut.Text))).TotalDays);
                        decimal PrixTotal = (MaResa.PrixDeBase) * compteJour;
                        this.lblPrix.Text = PrixTotal.ToString();
                        this.ddlPaiement.SelectedValue = this.ddlPaiement.SelectedValue;
                        this.lblDuree.Text = compteJour.ToString();
                    }

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
                string Prix = this.lblPrix.Text;
                bool Statut = true;
                int ModePaiement = 0;
                if (this.ddlPaiement.SelectedValue != null)
                {
                    ModePaiement = Convert.ToInt32(this.ddlPaiement.SelectedValue);                    
                }
                else
                {
                    ModePaiement = 1;
                }
                
                DaoReservation daoReservation = new DaoReservation();

                daoReservation.SetReservation(idclient, idhebergement, datedebut, datefin, Prix, Statut, ModePaiement);
                Response.Redirect("BackendCommandes.aspx",false);
                
            }
            catch(Exception ex)
            {
                this.lblErreur.Visible = true;
                this.lblErreur.Text = ex.Message;
                ((SiteMaster)Page.Master).AddError(ex);
            }
            
        }

        protected void btnPrix_Click(object sender, EventArgs e)
        {

        }
    }
}
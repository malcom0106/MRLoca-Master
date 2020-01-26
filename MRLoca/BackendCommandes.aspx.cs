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
    public partial class BackendCommandes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                DaoReservation daoreservation = new DaoReservation();
                List<Commande> MesCommandes = daoreservation.GetCommande(Utilisateur.IdClient);
                if (MesCommandes.Count() > 0)
                {
                    this.lvwHebergement.DataSource = MesCommandes;
                    this.lvwHebergement.DataBind();
                }
                else
                {
                    this.pnlModalMessage.Visible = true;
                }
            }
            catch (Exception ex) 
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }
               
        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                //Recuperation des variables.
                string Message = this.txtmessage.Text;
                string Sujet = this.txtSujet.Text;
                int IdDestinataire = Convert.ToInt32(this.hidDestinataire.Value);
                int IdHebergement = Convert.ToInt32(this.hidHebergementMessage.Value);
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                int IdExpediteur = Utilisateur.IdClient;

                // Variables stockées en BDD
                DaoMessage daoMessage = new DaoMessage();
                daoMessage.InsertMessage(IdExpediteur, IdDestinataire, Sujet, Message, IdHebergement);
                Response.Redirect("BackendMessagerie.aspx", false);
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }

        protected void btnAvis_Click(object sender, EventArgs e)
        {
            try
            {
                //Recuperation des variables.
                string Avis = this.txtAvis.Text;
                int Note = Convert.ToInt32(this.txtNote.Text);
                int IdHebergement = Convert.ToInt32(this.hidHebergementAvis.Value);
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                int IdClient = Utilisateur.IdClient;
                // Variables stockées en BDD
                DaoAvis daoAvis = new DaoAvis();
                daoAvis.InsertAvisHebergement(IdClient, IdHebergement, Note, Avis);
                Response.Redirect("BackendCommandes.aspx", false);
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }

        }
    }
}
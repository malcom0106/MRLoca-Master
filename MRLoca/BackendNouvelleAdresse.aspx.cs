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
    public partial class BackendNouvelleAdresse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btnmodifier_Click(object sender, EventArgs e)
        {
            string nom = this.TxtNomAdresse.Text;
            string numero = this.TxtNumero.Text;
            string voie = this.txtVoie.Text;
            string codepostal = this.txtCodePostal.Text;
            string ville = this.txtVille.Text;
            Client Utilisateur = null;
            if (Session["Client"] != null)
            {
                Utilisateur = new Client();
                Utilisateur = (Client)Session["Client"];
            }
            int IdClient = Utilisateur.IdClient;
            DaoAdresse daoAdresse = new DaoAdresse();
            try
            {
                daoAdresse.InsertAdresseClient(IdClient, nom, numero, voie, codepostal, ville);
                 Response.Redirect("BackendMesAdresses.aspx");
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = this.TxtNomAdresse.Text;
                string numero = this.TxtNumero.Text;
                string voie = this.txtVoie.Text;
                string codepostal = this.txtCodePostal.Text;
                string ville = this.txtVille.Text;
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = new Client();
                    Utilisateur = (Client)Session["Client"];
                }
                int IdClient = Utilisateur.IdClient;
                DaoAdresse daoAdresse = new DaoAdresse();
                daoAdresse.InsertAdresseClient(IdClient, nom, numero, voie, codepostal, ville);
            } 
            catch( Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }
    }
}
using MRLoca.Dao;
using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class CreerCompte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = this.txtNom.Text.Trim().ToUpper();
                string prenom = this.txtPrenom.Text.Trim();
                string login = this.TxtLogin.Text.Trim();
                string password = this.txtPassword2.Text.Trim();
                string email = this.txtEmail2.Text.Trim();
                string telephone = this.txtTelephone.Text.Trim();
                bool type = this.CbxProprietaire.Checked;

                string nomAdresse = this.TxtNomAdresse.Text;
                string numero = this.TextNumero.Text;
                string voie = this.txtVoie.Text;
                string codepostal = this.txtCodePostal.Text;
                string ville = this.txtVille.Text;

                DaoClient daoClient = new DaoClient();
                daoClient.InsertClient(nom, prenom, login, password, email, telephone, type, nomAdresse, numero, voie, codepostal, ville);
                Client client = daoClient.GetUtilisateur(login, password);
                Session["Client"] = client;
                if (Session["Reservation"] != null)
                {
                    Response.Redirect("Paiement.aspx");
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
    }
}
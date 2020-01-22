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
    public partial class BackendEditClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }                
                this.txtNom.Text = Utilisateur.Nom;
                this.txtPrenom.Text = Utilisateur.Prenom;
                this.txtEmail.Text = Utilisateur.Email;
                this.txtTelephone.Text = Utilisateur.Telephone;
                if (Utilisateur.Type)
                {
                    this.cbxProprio.Checked = true;
                }
                else
                {
                    this.cbxProprio.Checked = false;
                }
            }            
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //RECUPERATION DES VALEURS MODIFIEES
                Client Utilisateur = (Client)Session["Client"];
                string idclient = Utilisateur.IdClient.ToString();
                string nom = this.txtNom.Text.Trim().ToUpper();
                string prenom = this.txtPrenom.Text.Trim();
                string password = this.txtPassword2.Text.Trim();
                string email = this.txtEmail.Text.Trim();
                string telephone = this.txtTelephone.Text.Trim();
                bool type = this.cbxProprio.Checked;

                //EXECUTION DE LA DAO
                DaoClient daoClient = new DaoClient();
                daoClient.UpdateClient(idclient, nom, prenom, password, email, telephone, type);
                Session["Client"] = daoClient.GetUtilisateurId(Convert.ToInt32(idclient));
                Response.Redirect("BackendEspaceClient.aspx", false);
            } 
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            

        }
    }
}
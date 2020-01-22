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
    public partial class BackendEditAdresse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdAdresse"] != null && Request.QueryString["IdAdresse"] != "")
                {
                    int IdAdresse = Convert.ToInt32(Request.QueryString["IdAdresse"]);
                    DaoAdresse daoAdresse = new DaoAdresse();

                    Adresse MonAdresse = daoAdresse.GetAdresse(IdAdresse);
                    if (MonAdresse != null)
                    {
                        this.TxtNomAdresse.Text = Convert.ToString(MonAdresse.Nom);
                        this.TxtNumero.Text = Convert.ToString(MonAdresse.Numero);
                        this.txtVoie.Text = Convert.ToString(MonAdresse.Voie);
                        this.txtCodePostal.Text = Convert.ToString(MonAdresse.CodePostal);
                        this.txtVille.Text = Convert.ToString(MonAdresse.Ville);
                        this.btnmodifier.CommandArgument = Convert.ToString(MonAdresse.IdAdresse);
                    }
                    else
                    {
                        Response.Redirect("BackendMesAdresses.aspx");
                    }
                }
                else
                {
                    Response.Redirect("BackendMesAdresses.aspx");
                }
            }
            
               
        }

        protected void btnmodifier_Click(object sender, EventArgs e)
        {
            try
            {
                //Recuperation de l'idAdresse
                int IdAdresse = Convert.ToInt32(((Button)sender).CommandArgument);
                DaoAdresse daoAdresse = new DaoAdresse();
                string nom = this.TxtNomAdresse.Text;
                string numero = this.TxtNumero.Text;
                string voie = this.txtVoie.Text;
                string codepostal = this.txtCodePostal.Text;
                string ville = this.txtVille.Text;
                daoAdresse.UpdateAdresse(IdAdresse, nom, numero, voie, codepostal, ville);
                Response.Redirect("BackendMesAdresses.aspx");
            } 
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }            
        }
    }
}
using MRLoca.Dao;
using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class BackendNouvelHebergement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DaoDataDDL daoDataDDL = new DaoDataDDL();
                this.ddlType = Functions.GenerationDDL(this.ddlType, daoDataDDL.GetDataDDL("IdTypeHebergement", "NomHebergement", "TypeHebergement", null, null));
                this.ddlType.DataBind();
            }
            
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {            
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                if (this.fudPhoto.HasFile)
                {
                    if (ValidationExtensions(this.fudPhoto.PostedFile.ContentType) && this.fudPhoto.PostedFile.ContentLength < 2500000)
                    {
                        string nomhebergement = this.txtNom.Text;
                        int idType = Convert.ToInt32(this.ddlType.SelectedValue);
                        string description = this.txtDescription.Text;
                        int IdClient = Utilisateur.IdClient;
                        string prixdebase = (this.txtPrixDeBase.Text).Replace(".", ",");
                        decimal prixDeBase = Convert.ToDecimal(prixdebase);
                        string numero = this.TxtNumero.Text;
                        string voie = this.txtVoie.Text;
                        string codePostal = this.txtCodePostal.Text;
                        string ville = this.txtVille.Text;

                        Regex reg = new Regex(@"\W");
                        string extension = (this.fudPhoto.FileName).Substring((this.fudPhoto.FileName).LastIndexOf(".") + 1);
                        string nomficher = (Convert.ToString(Utilisateur.IdClient) +"_" + DateTime.Now.ToString() + this.fudPhoto.FileName).Trim();
                        string nomPhoto = reg.Replace(nomficher, string.Empty)+"."+ extension;
                        string FileNameComplete = Server.MapPath("~/Images/Upload/") + nomPhoto;
                        DaoHebergement daoHebergement = new DaoHebergement();
                        daoHebergement.InsertHebergement(nomhebergement, idType, description, IdClient, prixDeBase, numero, voie, codePostal, ville, nomPhoto);
                        this.fudPhoto.SaveAs(FileNameComplete);
                        Response.Redirect("BackendHebergements.aspx", false);
                        //Rechargement de l'objet image
                        //System.Drawing.Image image = System.Drawing.Image.FromFile(filenameComplete);


                    }
                    else
                    {
                        this.lblImageErreur.Text = "L'extension ou la taille de l'image est incorrect. Taille < 2.5Mo. Format autorisé : JPG JPEG PNG BMP GIF";
                        this.lblImageErreur.CssClass = "Bg-Danger";
                        this.lblImageErreur.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }            
        }
        /// <summary>
        /// Validation d'une extension d'image
        /// </summary>
        /// <returns>Boolean : True ou False</returns>
        public bool ValidationExtensions(string ext)
        {
            List<string> ListeExtensions = new List<string>();
            ListeExtensions.Add("image/jpeg");
            ListeExtensions.Add("image/jpg");
            ListeExtensions.Add("image/bmp");
            ListeExtensions.Add("image/gif");
            ListeExtensions.Add("image/png");

            return ListeExtensions.Contains(ext);
        }
    }
}
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
            DaoDataDDL daoDataDDL = new DaoDataDDL();
            this.ddlType = Functions.GenerationDDL(this.ddlType, daoDataDDL.GetDataDDL("IdTypeLgt", "NomLgt", "TypeLgt", null, null));
            this.ddlType.DataBind();
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
                        Regex reg = new Regex("[*'\",_&#^@]");
                        string filename = Convert.ToString(Utilisateur.IdClient) + reg.Replace(this.fudPhoto.FileName, string.Empty);
                        string filenameComplete = Server.MapPath("~/Images/Upload/") + filename;
                        this.fudPhoto.SaveAs(filenameComplete);

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
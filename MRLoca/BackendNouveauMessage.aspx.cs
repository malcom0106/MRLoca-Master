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
    public partial class BackendNouveauMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["IdDestinataire"] != null && Request.QueryString["IdDestinataire"] != "")
                    {
                        //Tester l'id transmis... 
                    }
                    else
                    {
                        Response.Redirect("BackendEspaceClient.aspx");
                    }
                }
            } 
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }                
        }

        protected void btnEnvoye_Click(object sender, EventArgs e)
        {
            try
            {
                string Message = this.txtmessage.Text;
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                int IdExpediteur = Utilisateur.IdClient;
                int IdDestinataire = Convert.ToInt32(Request.QueryString["IdDestinataire"]);
                DaoMessage daoMessage = new DaoMessage();
                daoMessage.InsertMessage(IdExpediteur, IdDestinataire, Message);
                Response.Redirect("BackendMessagerie.aspx");
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
           
        }
    }
}
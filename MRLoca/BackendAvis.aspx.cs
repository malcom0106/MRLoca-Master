using MRLoca.Dao;
using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class BackendAvis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.litAvis.Text = GenerationAvis();
        }
        private string GenerationAvis()
        {
            DaoHebergement daohebergement = new DaoHebergement();
            Client Utilisateur = null;
            if (Session["Client"] != null)
            {
                Utilisateur = (Client)Session["Client"];
            }
            int IdClient = Utilisateur.IdClient;
            List<Hebergement> listeHebergement = daohebergement.GetHebergementProprietaire(IdClient);

            StringBuilder CodeAvis = new StringBuilder();
            CodeAvis.Append("<div class=\"accordion\" id=\"accordionExample\">");
            
            int i = 0;
            foreach (Hebergement hebergement in listeHebergement)
            {
                DaoAvis daoAvis = new DaoAvis();
                List<Avis> listeAvis = daoAvis.GetAvisHebergement(hebergement.IdHebergement);
                //Creation du bouton du collapse
                if (listeAvis.Count() > 0)
                {
                    CodeAvis.Append("<div class=\"card\">");
                    CodeAvis.Append("<div class=\"card - header\" id=\"heading" + i + "\">");
                    CodeAvis.Append("<h2 class=\"mb-0\">");
                    CodeAvis.Append("<button class=\"btn btn-secondary collapsed\" type=\"button\" data-toggle=\"collapse\" data-target=\"#collapse" + i + "\" aria-expanded=\"false\" aria-controls=\"collapse" + i + "\">");
                    CodeAvis.Append(hebergement.Nom + "  <span class=\"badge badge-light\">" + (listeAvis.Count()).ToString() + "</span>");
                    CodeAvis.Append("</button>");
                    CodeAvis.Append("</h2></div> ");

                    //Les avis de cette hebergement
                    CodeAvis.Append("<div id=\"collapse" + i + "\" class=\"collapse\" aria-labelledby=\"heading" + i + "\" data-parent=\"#accordionExample\"><div class=\"card-body\">");
                    CodeAvis.Append("<div class=\"list-group\">");
                    foreach (Avis avis in listeAvis)
                    {
                        CodeAvis.Append("<span class=\"list-group-item list-group-item-action border\">");
                        CodeAvis.Append("<div class=\"d-flex w-100 justify-content-between\">");
                        CodeAvis.Append("<h6 class=\"mb-1\">Note : " + avis.Note  +"</h6>");
                        CodeAvis.Append("<small>"+(avis.Date).ToString("d")+"</small>");
                        CodeAvis.Append("</div>");
                        CodeAvis.Append("<p class=\"mb-1\">" + avis.Commentaire + "</p>");
                        CodeAvis.Append("</span");
                    }                    
                    CodeAvis.Append("</div>");
                    CodeAvis.Append("</div></div>");
                    CodeAvis.Append("</div>");
                    i++;
                }
                
            }
            CodeAvis.Append("</div>");
            return CodeAvis.ToString();
        }
    }
}
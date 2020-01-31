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
    public partial class BackendMessagerie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Client Utilisateur = null;
                    if (Session["Client"] != null)
                    {
                        Utilisateur = new Client();
                        Utilisateur = (Client)Session["Client"];
                    }
                    DaoMessage daoMessage = new DaoMessage();
                    List<Message> ListeMessages = daoMessage.GetMessageClient(Utilisateur.IdClient);

                    //MESSAGERIE
                    StringBuilder MaMessagerie = new StringBuilder();
                    
                    List<int> ListeHebergement =
                        (from Message in ListeMessages
                        group Message by Message.Logement.IdHebergement into IdHebergement
                        orderby IdHebergement.Key
                        select IdHebergement.Key).ToList();

                    if (ListeHebergement.Count > 0)
                    {
                        Utilisateur = null;
                        if (Session["Client"] != null)
                        {
                            Utilisateur = new Client();
                            Utilisateur = (Client)Session["Client"];
                        }

                        MaMessagerie.Append("<div id=\"messagerie\" class=\"row col-12\">");
                        MaMessagerie.Append("<div class=\"col-12 col-md-3 my-2\">");
                        MaMessagerie.Append("<ul class=\"list-group\">");
                        int numerotationHebergement = 1;
                        List<int> ClientIdMessagerie = new List<int>();
                        foreach (int hebergement in ListeHebergement)
                        {

                            DaoHebergement daoHebergement = new DaoHebergement();
                            Hebergement MonHebergement = daoHebergement.GetHebergement(hebergement);
                            MaMessagerie.Append("<a class=\"btn btn-light list-group-item\" data-toggle=\"collapse\" data-target=\"#collapse" + numerotationHebergement + "\" aria-expanded=\"false\" aria-controls=\"collapse" + numerotationHebergement + "\">" + MonHebergement.Nom + "</a>");
                            numerotationHebergement++;
                        }
                        MaMessagerie.Append("</ul>");
                        MaMessagerie.Append("</div>");
                        int numerotationsujet2 = 1;
                        foreach (int Hebergement in ListeHebergement)
                        {
                            //Recuperer les clients unique qui parlent de cette hebergement
                            List<int> clientiddest = (from m in ListeMessages
                                                      where m.Logement.IdHebergement.Equals(Hebergement)
                                                      group m by m.IdDestinataire into ClientID
                                                      orderby ClientID.Key
                                                      select ClientID.Key).ToList();
                            List<int> clientidexp = (from m in ListeMessages
                                                     where m.Logement.IdHebergement.Equals(Hebergement)
                                                     group m by m.IdExpediteur into ClientID
                                                     orderby ClientID.Key
                                                     select ClientID.Key).ToList();
                            ClientIdMessagerie = new List<int>();
                            ClientIdMessagerie.AddRange(clientiddest);
                            ClientIdMessagerie.AddRange(clientidexp);
                            ClientIdMessagerie = ClientIdMessagerie.Distinct().ToList();
                            ClientIdMessagerie.Remove(Utilisateur.IdClient);


                            DaoHebergement daoHebergement = new DaoHebergement();
                            Hebergement MonHebergement = daoHebergement.GetHebergement(Hebergement);
                            MaMessagerie.Append("<div class=\"col-12 col-md-9 my-2 collapse cart\" id=\"collapse" + numerotationsujet2 + "\">");
                            MaMessagerie.Append("<div class=\"card-header\">" + MonHebergement.Nom + "</div>");
                            List<Message> ListeDeMesMessages = new List<Message>();
                            foreach (int c in ClientIdMessagerie)
                            {
                                DaoClient daoClient = new DaoClient();
                                Client monclient = daoClient.GetUtilisateurId(c);
                                
                                MaMessagerie.Append("<a class=\"btn btn-light card-body col-12\" data-toggle=\"collapse\" href=\"#collapse" + monclient.Nom + "\" role=\"button\" aria-expanded=\"false\" aria-controls=\"collapse" + monclient.Nom + "\">");
                                MaMessagerie.Append("<h5 class=\"card-title\">"+ monclient.Nom + " "+ monclient.Prenom + "</h5>");
                                MaMessagerie.Append("<div class=\"collapse\" id=\"collapse" + monclient.Nom + "\">");
                                MaMessagerie.Append("<div class=\"container\">");
                                List<Message> MesMessages = ListeMessages.Where(m => m.Logement.IdHebergement.Equals(Hebergement)).ToList();
                                List<Message> MesMessages1 = MesMessages.Where(m => m.IdExpediteur.Equals(c)).ToList();
                                List<Message> MesMessages2 = MesMessages.Where(m => m.IdDestinataire.Equals(c)).ToList();
                                
                                ListeDeMesMessages.AddRange(MesMessages1);
                                ListeDeMesMessages.AddRange(MesMessages2);
                                ListeDeMesMessages = ListeDeMesMessages.Distinct().ToList();

                                foreach (Message message in ListeDeMesMessages)
                                {
                                    if (message.IdExpediteur == Utilisateur.IdClient)
                                    {
                                        //Expediteur
                                        MaMessagerie.Append("<div class=\"row justify-content-start my-1\"><div class=\"border border-light rounded bg-light col-8\">" + message.LeMessage + "</div></div>");
                                    }
                                    else
                                    {
                                        //Destinataire
                                        MaMessagerie.Append("<div class=\"row justify-content-end my-1\"><div class=\"border border-primary rounded bg-primary col-8\"><div>" + message.LeMessage + "</div><div>" + message.Expediteur.Nom + "</div></div></div>");
                                    }
                                }
                                MaMessagerie.Append("</div>");
                                string IdExp = Convert.ToString(Utilisateur.IdClient);
                                string sujet ="0";
                                string idDest = Convert.ToString(c);
                                MaMessagerie.Append("<button type =\"button\" class=\"btn btn-primary\" onclick=\"envoisMessage('"+ idDest + "' , '"+ sujet + "', '"+ Hebergement.ToString() + "'); \" >Repondre</button>");
                                MaMessagerie.Append("</a></div>");                                
                            }
                            ClientIdMessagerie = null;
                            MaMessagerie.Append("</div>");

                            numerotationsujet2++;
                        }
                    }

                    this.MaMessagerie.Text = MaMessagerie.ToString();
                }
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                string Message = this.txtmessage.Text;
                string Sujet = this.hidSujet.Value;
                int IdDestinataire = Convert.ToInt32(this.hidDestinataire.Value);
                int IdHebergement = Convert.ToInt32(this.hidHebergement.Value);
                Client Utilisateur = null;                
                if (Session["Client"] != null)
                {
                    Utilisateur = (Client)Session["Client"];
                }
                int IdExpediteur = Utilisateur.IdClient;


                DaoMessage daoMessage = new DaoMessage();
                daoMessage.InsertMessage(IdExpediteur, IdDestinataire,Sujet, Message, IdHebergement);
                Response.Redirect("BackendMessagerie.aspx");
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }
    }
}
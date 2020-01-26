﻿using MRLoca.Dao;
using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    this.litMessage.Text = "<h4>Tous</h4>";
                    List<Message> ListeMessages = daoMessage.GetMessageClient(Utilisateur.IdClient);

                    this.lvwMessage.DataSource = ListeMessages;
                    this.lvwMessage.DataBind();
                }
            }
            catch(Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }

        protected void btn_tous_Click(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = new Client();
                    Utilisateur = (Client)Session["Client"];
                }
                DaoMessage daoMessage = new DaoMessage();
                this.litMessage.Text = "<h4>Tous</h4>";
                this.lvwMessage.DataSource = daoMessage.GetMessageClient(Utilisateur.IdClient);
                this.lvwMessage.DataBind();
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btn_recus_Click(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = new Client();
                    Utilisateur = (Client)Session["Client"];
                }
                DaoMessage daoMessage = new DaoMessage();
                List<Message> MessagesRecus = new List<Message>();
                foreach (Message item in daoMessage.GetMessageClient(Utilisateur.IdClient))
                {
                    if (item.IdDestinataire == Utilisateur.IdClient)
                    {
                        MessagesRecus.Add(item);
                    }
                }
                this.litMessage.Text = "<h4>Messages Reçus</h4>";
                this.lvwMessage.DataSource = MessagesRecus;
                this.lvwMessage.DataBind();
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void btn_envoyes_Click(object sender, EventArgs e)
        {
            try
            {
                Client Utilisateur = null;
                if (Session["Client"] != null)
                {
                    Utilisateur = new Client();
                    Utilisateur = (Client)Session["Client"];
                }
                DaoMessage daoMessage = new DaoMessage();
                List<Message> MessagesEnvoyes = new List<Message>();
                foreach (Message item in daoMessage.GetMessageClient(Utilisateur.IdClient))
                {
                    if (item.IdExpediteur == Utilisateur.IdClient)
                    {
                        MessagesEnvoyes.Add(item);
                    }
                }
                this.litMessage.Text = "<h4>Messages Envoyés</h4>";
                this.lvwMessage.DataSource = MessagesEnvoyes;
                this.lvwMessage.DataBind();
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
            
        }

        protected void lvwMessage_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            Client Utilisateur = null;
            if (Session["Client"] != null)
            {
                Utilisateur = new Client();
                Utilisateur = (Client)Session["Client"];
            }
            this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            DaoMessage daoMessage = new DaoMessage();
            this.litMessage.Text = "<h4>Tous</h4>";
            List<Message> ListeMessages = daoMessage.GetMessageClient(Utilisateur.IdClient);

            this.lvwMessage.DataSource = ListeMessages;
            this.lvwMessage.DataBind();
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
                Response.Redirect("BackendMessagerie.aspx",false);
            }
            catch (Exception ex)
            {
                ((backend)Page.Master).AddError(ex);
            }
        }
    }
}
using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoMessage : DataAccess
    {
        public DaoMessage() : base()
        {

        }
        public List<Message> GetMessageClient(int IdClient)
        {
            try
            {
                string sql = "sp_GetMessagesClient";
                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));


                base.GetDataReader(sql, sqlParameters);
                List<Message> ListeMessages = new List<Message>();
                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        int IdMessagerie = Convert.ToInt32(base.sqlDataReader["IdMessagerie"]);
                        int IdExpediteur = Convert.ToInt32(base.sqlDataReader["IdExpediteur"]); ;
                        int IdDestinataire = Convert.ToInt32(base.sqlDataReader["IdDestinataire"]); ;
                        string LeMessage = Convert.ToString(base.sqlDataReader["Message"]);
                        DateTime DateMessage = Convert.ToDateTime(base.sqlDataReader["Date"]);
                        bool Statut = Convert.ToBoolean(base.sqlDataReader["Statut"]);
                        string sujet = Convert.ToString(base.sqlDataReader["Sujet"]);

                        Client Expediteur = new Client();
                        Expediteur.IdClient = 0;
                        Expediteur.Nom = Convert.ToString(base.sqlDataReader["NomExpediteur"]);
                        Expediteur.Prenom = Convert.ToString(base.sqlDataReader["PrenomExpediteur"]);
                        Expediteur.Telephone = Convert.ToString(base.sqlDataReader["TelephoneExpediteur"]);
                        Expediteur.Email = Convert.ToString(base.sqlDataReader["EmailExpediteur"]);
                        Expediteur.Type = Convert.ToBoolean(base.sqlDataReader["TypeExpediteur"]);

                        Client Destinataire = new Client();
                        Destinataire.Nom = Convert.ToString(base.sqlDataReader["NomDestinataire"]);
                        Destinataire.Prenom = Convert.ToString(base.sqlDataReader["PrenomDestinataire"]);
                        Destinataire.Telephone = Convert.ToString(base.sqlDataReader["TelephoneDestinataire"]);
                        Destinataire.Email = Convert.ToString(base.sqlDataReader["EmailDestinataire"]);
                        Destinataire.Type = Convert.ToBoolean(base.sqlDataReader["TypeDestinataire"]);

                        Hebergement hebergement = new Hebergement();
                        hebergement.IdHebergement = Convert.ToInt32(base.sqlDataReader["IdHebergement"]);
                        hebergement.Nom = Convert.ToString(base.sqlDataReader["NomHebergement"]);
                        hebergement.Photo = Convert.ToString(base.sqlDataReader["Photo"]);
                        hebergement.Type = Convert.ToString(base.sqlDataReader["Type"]);

                        Message monMessage = new Message(IdMessagerie, IdExpediteur, IdDestinataire, LeMessage, DateMessage, Statut, Expediteur, Destinataire, hebergement, sujet);

                        ListeMessages.Add(monMessage);
                    }
                }
                sqlConnection.Close();
                sqlDataReader.Close();
                return ListeMessages;
            } catch ( Exception ex)
            {
                throw ex;
            }
            
        }
        public void InsertMessage(int idexpediteur, int iddestinataire, string message)
        {
            try
            {
                string sql = "sp_InsertMessage";
                Functions MesFonction = new Functions();

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdExpediteur", idexpediteur));
                sqlParameters.Add(new SqlParameter("@IdDestinataire", iddestinataire));
                sqlParameters.Add(new SqlParameter("@Message", message));

                base.SetData(sql, sqlParameters);
                sqlConnection.Close();
            }
            catch ( Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
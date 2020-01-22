using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoClient : DataAccess
    {

        public DaoClient() : base()
        {

        }

        /// <summary>
        /// Vérification du login et mdp
        /// </summary>
        /// <param name="login">Login du client</param>
        /// <param name="password">Mot de Passe du Client</param>
        /// <returns>Retourne le client s'il existe. </returns>
        public Client GetUtilisateur(string login, string password)
        {
            try
            {
                string sql = "sp_getClient";

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@login", login));
                sqlParameters.Add(new SqlParameter("@password", password));


                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters);
                Client Utilisateur = null;
                if (base.sqlDataReader.HasRows)
                {
                    Utilisateur = new Client();
                    while (base.sqlDataReader.Read())
                    {
                        Utilisateur.IdClient = Convert.ToInt32(base.sqlDataReader["IdClient"]);
                        Utilisateur.Nom = base.sqlDataReader["Nom"].ToString();
                        Utilisateur.Prenom = base.sqlDataReader["Prenom"].ToString();
                        Utilisateur.Login = base.sqlDataReader["Login"].ToString();
                        Utilisateur.Password = base.sqlDataReader["Password"].ToString();
                        Utilisateur.Email = base.sqlDataReader["Email"].ToString();
                        Utilisateur.Telephone = base.sqlDataReader["Telephone"].ToString();
                        Utilisateur.Type = Convert.ToBoolean(base.sqlDataReader["Type"]);
                    }
                }
                sqlConnection.Close();
                sqlDataReader.Close();
                return Utilisateur;
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public Client GetUtilisateurId(int IdClient)
        {
            try
            {
                string sql = "sp_GetUtilisateurId";

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));

                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters);

                Client Utilisateur = null;
                if (base.sqlDataReader.HasRows)
                {
                    Utilisateur = new Client();
                    while (base.sqlDataReader.Read())
                    {
                        Utilisateur.IdClient = Convert.ToInt32(base.sqlDataReader["IdClient"]);
                        Utilisateur.Nom = base.sqlDataReader["Nom"].ToString();
                        Utilisateur.Prenom = base.sqlDataReader["Prenom"].ToString();
                        Utilisateur.Login = base.sqlDataReader["Login"].ToString();
                        Utilisateur.Password = base.sqlDataReader["Password"].ToString();
                        Utilisateur.Email = base.sqlDataReader["Email"].ToString();
                        Utilisateur.Telephone = base.sqlDataReader["Telephone"].ToString();
                        Utilisateur.Type = Convert.ToBoolean(base.sqlDataReader["Type"]);
                    }
                }
                sqlConnection.Close();
                sqlDataReader.Close();
                return Utilisateur;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void InsertClient(string nom, string prenom, string login, string password, string email, string telephone, bool type, string NomAdresse, string numero, string voie, string codepostal, string ville)
        {
            try
            {
                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@nom", nom));
                sqlParameters.Add(new SqlParameter("@prenom", prenom));
                sqlParameters.Add(new SqlParameter("@login", login));
                sqlParameters.Add(new SqlParameter("@password", password));
                sqlParameters.Add(new SqlParameter("@email", email));
                sqlParameters.Add(new SqlParameter("@telephone", telephone));
                sqlParameters.Add(new SqlParameter("@type", type));
                sqlParameters.Add(new SqlParameter("@nomadresse", NomAdresse));
                sqlParameters.Add(new SqlParameter("@numero", numero));
                sqlParameters.Add(new SqlParameter("@voie", voie));
                sqlParameters.Add(new SqlParameter("@codepostal", codepostal));
                sqlParameters.Add(new SqlParameter("@ville", ville));

                string sql = "sp_setClient";
                //Execution de GetDataReader Erité de DataAccess
                base.SetData(sql, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void UpdateClient(string idclient, string nom, string prenom, string password, string email, string telephone, bool type)
        {
            try
            {
                string sql = "sp_UpdateClient";
                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@Nom", nom));
                sqlParameters.Add(new SqlParameter("@Prenom", prenom));
                sqlParameters.Add(new SqlParameter("@Email", email));
                sqlParameters.Add(new SqlParameter("@Telephone", telephone));
                sqlParameters.Add(new SqlParameter("@Type", type));
                sqlParameters.Add(new SqlParameter("@Password", password));
                sqlParameters.Add(new SqlParameter("@IdClient", idclient));

                base.SetData(sql, sqlParameters);
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
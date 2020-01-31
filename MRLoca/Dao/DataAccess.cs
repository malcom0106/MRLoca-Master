using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DataAccess
    {
        // Declaration des objets SqlConnection et SqlDataReader en Global
        public SqlConnection sqlConnection;
        public SqlDataReader sqlDataReader;

        // Declaration de variable global (Get Set) - Stockage du message d'erreur 
        public string ErrorMsg { get; set; } 

        // Constructeur contenant la chaine de connection et l'objet pour ce connecter. 
        public DataAccess() 
        {
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            sqlConnection = new SqlConnection(strcon);            
        }


        /// <summary>
        /// Permet de retourner un sqlDataReader
        /// </summary>
        /// <param name="sql">Ma requete en SQL </param>
        /// <param name="sqlParameter">Les parametres à passer dans ma BDD sous forme d'une list<SqlParameter> </param>
        /// <returns>Retourne rien mais stocke la reponse dans la variable global sqlDataReader</returns>
        public void GetDataReader(string sql, List<SqlParameter> sqlParameters)
        {
            //requete SQL
            string sqlString = sql;          

            //Objet pour executer la requete
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);            
            try
            {
                //On se connecte à la bdd
                sqlConnection.Open();

                // Verification de la presence de parametre Sql et utilisation des procedures stockées
                if(sqlParameters != null && sqlParameters.Count > 0)
                {
                    sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                }

                //On execute l'operation de SQL (dans ce cas) qui nous renvois un tableau
                //Les donnees sont stockéesdans un objet SqlDataReader
                sqlDataReader = sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                
                // Stockage dans la global du message d'erreur 
                ErrorMsg = ex.Message;
                throw ex;
                // Passage de la boolean en true 

            }            
        }


        /// <summary>
        /// Execute une requete et ne renvoie rien.
        /// </summary>
        /// <param name="sql">Ma requete en SQL</param>
        /// <param name="sqlParameters">Les parametres à passer dans ma BDD sous forme d'une list<SqlParameter> </param>
        public void SetData(string sql, List<SqlParameter> sqlParameters)
        {
            //requete SQL
            string sqlString = sql;
            List<SqlParameter> parametreInsert = sqlParameters;
            //Objet pour executer la requete
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);  
            try
            {
                //On se connecte à la bdd
                sqlConnection.Open();

                // Verification de la presence de parametre Sql 
                if (parametreInsert != null && parametreInsert.Count() > 0)
                {
                    sqlCommand.Parameters.AddRange(parametreInsert.ToArray());
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                }

                //On execute l'operation de SQL (dans ce cas) qui nous renvois un tableau
                //Les donnees sont stockéesdans un objet SqlDataReader
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Stockage dans la global du message d'erreur 
                ErrorMsg = ex.Message;
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}
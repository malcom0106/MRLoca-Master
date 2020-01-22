using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoAdresse : DataAccess
    {
        public DaoAdresse() : base()
        {

        }
        public void InsertAdresse(string nom, string numero, string voie, string codepostal, string ville)
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@nom", nom));
                sqlParameters.Add(new SqlParameter("@numero", numero));
                sqlParameters.Add(new SqlParameter("@voie", voie));
                sqlParameters.Add(new SqlParameter("@codepostal", codepostal));
                sqlParameters.Add(new SqlParameter("@ville", ville));

                string sql = "sp_setAdresse";
                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlDataReader.Close();
            }
            
        }
        
        /// <summary>
        /// Lister les adresses d'un client via son ID
        /// </summary>
        /// <param name="IdClient"></param>
        /// <returns>Retourne une liste d'adresse rattaché au client</returns>
        public List<Adresse> GetAdresseClient(int IdClient)
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));
                string sql = "sp_GetAdressesClient";
                List<Adresse> ListeAdresse = null;
                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters);
                if (base.sqlDataReader.HasRows)
                {
                    ListeAdresse = new List<Adresse>();
                    while (base.sqlDataReader.Read())
                    {
                        Adresse adresse = new Adresse();
                        adresse.IdAdresse = Convert.ToInt32(base.sqlDataReader["IdAdresse"]);
                        adresse.Nom = Convert.ToString(base.sqlDataReader["Nom"]);
                        adresse.Numero = Convert.ToString(base.sqlDataReader["Numero"]);
                        adresse.Voie = Convert.ToString(base.sqlDataReader["Voie"]);
                        adresse.CodePostal = Convert.ToString(base.sqlDataReader["CodePostal"]);
                        adresse.Ville = Convert.ToString(base.sqlDataReader["Ville"]);
                        ListeAdresse.Add(adresse);
                    }
                }
                return ListeAdresse;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Requete de recherche d'une adresse via son ID
        /// </summary>
        /// <returns>Retourne une Adresse via son iD</returns>
        public Adresse GetAdresse(int IdAdresse)        
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@IdAdresse", IdAdresse));
                string sql = "sp_GetAdresse";
                List<Adresse> ListeAdresse = null;
                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters) ;
                Adresse adresse = null;
                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        adresse = new Adresse();
                        adresse.IdAdresse = Convert.ToInt32(base.sqlDataReader["IdAdresse"]);
                        adresse.Nom = Convert.ToString(base.sqlDataReader["Nom"]);
                        adresse.Numero = Convert.ToString(base.sqlDataReader["Numero"]);
                        adresse.Voie = Convert.ToString(base.sqlDataReader["Voie"]);
                        adresse.CodePostal = Convert.ToString(base.sqlDataReader["CodePostal"]);
                        adresse.Ville = Convert.ToString(base.sqlDataReader["Ville"]);
                    }
                }
                return adresse;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlDataReader.Close();
            }

        }

        /// <summary>
        /// Supprimer une adresse via son IdAdresse
        /// </summary>
        
        public void DelAdresse(int IdAdresse)
        {
            try
            {                
                string sql = "sp_DelAdresse";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@IdAdresse", IdAdresse));
                base.SetData(sql, sqlParameters);                
                base.sqlConnection.Close();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mettre à jour une adresse
        /// </summary>
        
        public void UpdateAdresse(int idAdresse, string nom,string numero, string voie, string codePostal, string ville)
        {
            try
            {
                string sql = "sp_UpdateAdresse"; 
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@IdAdresse", idAdresse));
                sqlParameters.Add(new SqlParameter("@NomAdresse", nom));
                sqlParameters.Add(new SqlParameter("@Numero", numero));
                sqlParameters.Add(new SqlParameter("@Voie", voie));
                sqlParameters.Add(new SqlParameter("@CodePostal", codePostal));
                sqlParameters.Add(new SqlParameter("@Ville", ville));
                base.SetData(sql, sqlParameters);
            } catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Ajouter une nouvelle adresse pour un client 
        /// </summary>
        
        public void InsertAdresseClient(int IdClient, string nom, string numero, string voie, string codePostal, string ville)
        {
            try
            {
                string sql = "sp_InsertAdresse";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));
                sqlParameters.Add(new SqlParameter("@NomAdresse", nom));
                sqlParameters.Add(new SqlParameter("@Numero", numero));
                sqlParameters.Add(new SqlParameter("@Voie", voie));
                sqlParameters.Add(new SqlParameter("@CodePostal", codePostal));
                sqlParameters.Add(new SqlParameter("@Ville", ville));

                base.SetData(sql, sqlParameters);
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
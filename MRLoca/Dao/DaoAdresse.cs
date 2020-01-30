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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@nom", nom),
                    new SqlParameter("@numero", numero),
                    new SqlParameter("@voie", voie),
                    new SqlParameter("@codepostal", codepostal),
                    new SqlParameter("@ville", ville)
                };

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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdClient", IdClient)
                };
                string sql = "sp_GetAdressesClient";
                List<Adresse> ListeAdresse = null;
                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters);
                if (base.sqlDataReader.HasRows)
                {
                    ListeAdresse = new List<Adresse>();
                    while (base.sqlDataReader.Read())
                    {
                        Adresse adresse = new Adresse
                        {
                            IdAdresse = Convert.ToInt32(base.sqlDataReader["IdAdresse"]),
                            Nom = Convert.ToString(base.sqlDataReader["Nom"]),
                            Numero = Convert.ToString(base.sqlDataReader["Numero"]),
                            Voie = Convert.ToString(base.sqlDataReader["Voie"]),
                            CodePostal = Convert.ToString(base.sqlDataReader["CodePostal"]),
                            Ville = Convert.ToString(base.sqlDataReader["Ville"])
                        };
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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdAdresse", IdAdresse)
                };
                string sql = "sp_GetAdresse";
                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters) ;
                Adresse adresse = null;
                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        adresse = new Adresse
                        {
                            IdAdresse = Convert.ToInt32(base.sqlDataReader["IdAdresse"]),
                            Nom = Convert.ToString(base.sqlDataReader["Nom"]),
                            Numero = Convert.ToString(base.sqlDataReader["Numero"]),
                            Voie = Convert.ToString(base.sqlDataReader["Voie"]),
                            CodePostal = Convert.ToString(base.sqlDataReader["CodePostal"]),
                            Ville = Convert.ToString(base.sqlDataReader["Ville"])
                        };
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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdAdresse", IdAdresse)
                };
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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdAdresse", idAdresse),
                    new SqlParameter("@NomAdresse", nom),
                    new SqlParameter("@Numero", numero),
                    new SqlParameter("@Voie", voie),
                    new SqlParameter("@CodePostal", codePostal),
                    new SqlParameter("@Ville", ville)
                };
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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdClient", IdClient),
                    new SqlParameter("@NomAdresse", nom),
                    new SqlParameter("@Numero", numero),
                    new SqlParameter("@Voie", voie),
                    new SqlParameter("@CodePostal", codePostal),
                    new SqlParameter("@Ville", ville)
                };

                base.SetData(sql, sqlParameters);
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
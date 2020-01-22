using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoFavori : DaoHebergement
    {
        public DaoFavori() : base()
        {

        }
        public List<Hebergement> GetFavoris(int IdClient)
        {
            try
            {
                List<Hebergement> ListeFavoris = new List<Hebergement>();
                string sql = "sp_GetFavoris";

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));


                base.GetDataReader(sql, sqlParameters);

                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        //Creer un nouvel hebergement
                        Hebergement hebergement = new Hebergement();

                        //Ajout dans la liste des hebergement de l'hebergement
                        ListeFavoris.Add(CreateHebergement(hebergement, base.sqlDataReader));
                    }
                }
                //Fermeture du datareader
                base.sqlDataReader.Close();
                //Fermeture de la bdd
                base.sqlConnection.Close();

                return ListeFavoris;
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public void AddFavori(int IdClient, int IdHebergement)
        {
            try
            {
                string sql = "sp_AddFavori";

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdHebergement", IdHebergement));
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));

                base.SetData(sql, sqlParameters);
                base.sqlConnection.Close();
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            

        }
        public void DelFavori(int IdClient, int IdHebergement)
        {
            try
            {
                string sql = "sp_DelFavori";

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdHebergement", IdHebergement));
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));

                base.SetData(sql, sqlParameters);
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
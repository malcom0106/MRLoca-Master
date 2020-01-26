using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoAvis : DataAccess
    {
        public DaoAvis() : base()
        {

        }

        /// <summary>
        /// Genere une liste d'avis concernant UN Hebergement 
        /// </summary>
        /// <returns>Retourne une Liste d'Avis Concernant un hebergement</returns>
        public List<Avis> GetAvisHebergement(int IdHebergement)
        {
            List<Avis> ListeAvis = null;
            try
            {
                // requete + parametres à transmettre.
                string sql = "sp_GetAvisHebergement";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add((new SqlParameter("@IdHebergement", IdHebergement)));

                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, sqlParameters);
                //Verification de recuperation de données 
                ListeAvis= new List<Avis>();
                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        Avis avis = new Avis();
                        avis.Date = Convert.ToDateTime(base.sqlDataReader["Date"]);
                        avis.Commentaire = Convert.ToString(base.sqlDataReader["Commentaire"]);
                        avis.Note = Convert.ToInt32(base.sqlDataReader["Note"]);
                        avis.Statut = Convert.ToBoolean(base.sqlDataReader["Statut"]);

                        avis.IdClient = Convert.ToInt32(base.sqlDataReader["IdClient"]);
                        DaoClient daoClient = new DaoClient();
                        avis.Client = daoClient.GetUtilisateurId(Convert.ToInt32(base.sqlDataReader["IdClient"]));

                        avis.IdHebergement = Convert.ToInt32(base.sqlDataReader["IdHebergement"]);
                        DaoHebergement daoHebergement = new DaoHebergement();
                        avis.Hebergement = daoHebergement.GetHebergement(Convert.ToInt32(base.sqlDataReader["IdHebergement"]));

                        ListeAvis.Add(avis);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return ListeAvis;
        }
        public void InsertAvisHebergement(int IdClient, int IdHebergement, int Note, string Commentaire)
        {
            try
            {
                // requete + parametres à transmettre.
                string sql = "sp_InsertAvisHebergement";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add((new SqlParameter("@IdClient", IdClient)));
                sqlParameters.Add((new SqlParameter("@IdHebergement", IdHebergement)));
                sqlParameters.Add((new SqlParameter("@Note", Note)));
                sqlParameters.Add((new SqlParameter("@Commentaire", Commentaire)));

                
                base.SetData(sql, sqlParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
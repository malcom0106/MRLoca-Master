using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoReservation : DataAccess
    {
        public DaoReservation() : base()
        {

        }
        public void SetReservation(int idclient, int idhebergement, DateTime datedebut, DateTime datefin, string prix, bool statut, int Paiement)
        {
            decimal prixTotal = Convert.ToDecimal(prix);
            try
            {
                String sql = "sp_SetReservation";

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdClient", idclient));
                sqlParameters.Add(new SqlParameter("@IdHebergement", idhebergement));
                sqlParameters.Add(new SqlParameter("@DateDebut", datedebut));
                sqlParameters.Add(new SqlParameter("@DateFin", datefin));
                sqlParameters.Add(new SqlParameter("@PrixTotal", prixTotal));
                sqlParameters.Add(new SqlParameter("@Statut", statut));
                sqlParameters.Add(new SqlParameter("@ModePaiement", Paiement));


                base.SetData(sql, sqlParameters);

                sqlConnection.Close();
            } catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public List<Commande> GetCommande(int idclient)
        {
            try
            {
                String sql = "sp_GetCommande";

                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdClient", idclient));

                List<Commande> ListeDesCommandes = new List<Commande>();
                base.GetDataReader(sql, sqlParameters);
                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        int IdReservation = Convert.ToInt32(base.sqlDataReader["IdReservation"]);
                        Client Locataire = null;
                        DateTime DateDebut = Convert.ToDateTime(base.sqlDataReader["DateDebut"]);
                        DateTime DateFin = Convert.ToDateTime(base.sqlDataReader["DateFin"]);
                        string PrixTotal = Convert.ToString(base.sqlDataReader["PrixTotal"]);
                        bool Statut = Convert.ToBoolean(base.sqlDataReader["Statut"]);
                        int ModePaiement = Convert.ToInt32(base.sqlDataReader["IdPaiement"]);

                        Hebergement Location = new Hebergement();
                        Location.IdHebergement = Convert.ToInt32(base.sqlDataReader["IdHebergement"]);
                        Location.Nom = Convert.ToString(base.sqlDataReader["Nom"]);
                        Location.Photo =Constants.CheminPhoto+Convert.ToString(base.sqlDataReader["NomPhoto"]);
                        Location.Nom = Convert.ToString(base.sqlDataReader["Nom"]);
                        Location.Type = Convert.ToString(base.sqlDataReader["NomHebergement"]);
                        Location.Description = Convert.ToString(base.sqlDataReader["Description"]);
                        DaoClient daoclient = new DaoClient();
                        Location.Proprietaire = daoclient.GetUtilisateurId(Convert.ToInt32(base.sqlDataReader["IdProprietaire"]));
                        Commande maCommande = new Commande(IdReservation, Locataire, Location, DateDebut, DateFin, PrixTotal, Statut, ModePaiement);
                        ListeDesCommandes.Add(maCommande);
                    }
                }
                return ListeDesCommandes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
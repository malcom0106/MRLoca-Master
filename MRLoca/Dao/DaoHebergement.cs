using MRLoca.Entities;
using MRLoca.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    //Heritage de DataAccess
    public class DaoHebergement: DataAccess
    {
        //Heritage du constructeur de DataAccess contenant l objet de connecter
        public DaoHebergement() : base()
        {
            
        }
        public List<Hebergement> GetAllHebergements()
        {
            try
            {
                //Execution de GetDataReader Erité de DataAccess            
                base.GetDataReader("sp_GetAllHebergements", null);

                //Declaration de Listehebergement
                List<Hebergement> ListeHebergement = null;

                //Creation d'une liste d'Hebergement si le reader contient au moins une ligne            
                if (base.sqlDataReader.HasRows)
                {
                    ListeHebergement = new List<Hebergement>();
                    while (base.sqlDataReader.Read())
                    {
                        //Creer un nouvel hebergement
                        Hebergement hebergement = new Hebergement();

                        //Ajout dans la liste des hebergement de l'hebergement
                        ListeHebergement.Add(CreateHebergement(hebergement, base.sqlDataReader));
                    }
                }
                //Fermeture du datareader
                base.sqlDataReader.Close();
                //Fermeture de la bdd
                base.sqlConnection.Close();

                return ListeHebergement;
            }
            catch( Exception ex)
            {
                throw ex;
            }
            
        }
        public Hebergement GetHebergement(int IdHebergement)
        {
            try
            {
                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdHebergement", IdHebergement));

                string sql = "sp_GetHebergement";
                //Execution de GetDataReader Erité de DataAccess

                base.GetDataReader(sql, sqlParameters);


                Hebergement hebergement = new Hebergement();
                //On parcourt les enregistrement (normalement UN SEUL) et on créé l'hebergement retourner           
                if (base.sqlDataReader.HasRows)
                {
                    while (base.sqlDataReader.Read())
                    {
                        hebergement = CreateHebergement(hebergement, base.sqlDataReader);
                    }
                }
                //Fermeture du datareader
                base.sqlDataReader.Close();
                //Fermeture de la bdd
                base.sqlConnection.Close();

                return hebergement;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public List<Hebergement> GetHebergementRecherche(Dictionary<string, string> recherche)
        {
            try
            {
                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@Departement", recherche["departement"]));
                sqlParameters.Add(new SqlParameter("@Type", recherche["type"]));


                List<Hebergement> ListeHebergement = null;
                string sql = "sp_GetHebergementRecherche";

                //Execution de GetDataReader Erité de DataAccess

                base.GetDataReader(sql, sqlParameters);

                //Creation d'une liste d'Hebergement si le reader contient au moins une ligne            
                if (base.sqlDataReader.HasRows)
                {
                    ListeHebergement = new List<Hebergement>();
                    while (base.sqlDataReader.Read())
                    {
                        //Creer un nouvel hebergement
                        Hebergement hebergement = new Hebergement();

                        //Ajout dans la liste des hebergement de l'hebergement
                        ListeHebergement.Add(CreateHebergement(hebergement, base.sqlDataReader));
                    }
                }
                //Fermeture du datareader
                base.sqlDataReader.Close();
                //Fermeture de la bdd
                base.sqlConnection.Close();

                return ListeHebergement;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public List<Hebergement> GetHebergementProprietaire(int IdClient)
        {
            try
            {
                //Creation du table de paratre SQL pour le mettre dans GetDataReader
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                //Creation d'un parametre SQL et ajout dans le tableau precedemment créé
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));

                List<Hebergement> ListeHebergement = null;
                string sql = "sp_GetHebergementProprietaire";

                //Execution de GetDataReader Erité de DataAccess

                base.GetDataReader(sql, sqlParameters);

                //Creation d'une liste d'Hebergement si le reader contient au moins une ligne            
                if (base.sqlDataReader.HasRows)
                {
                    ListeHebergement = new List<Hebergement>();
                    while (base.sqlDataReader.Read())
                    {
                        //Creer un nouvel hebergement
                        Hebergement hebergement = new Hebergement();

                        //Ajout dans la liste des hebergement de l'hebergement
                        ListeHebergement.Add(CreateHebergement(hebergement, base.sqlDataReader));
                    }
                }
                //Fermeture du datareader
                base.sqlDataReader.Close();
                //Fermeture de la bdd
                base.sqlConnection.Close();

                return ListeHebergement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Hebergement CreateHebergement(Hebergement hebergement, SqlDataReader SqlDataReader)
        {
            try
            {
                hebergement.IdHebergement = Convert.ToInt32(base.sqlDataReader["IdHebergement"]);
                hebergement.Nom = base.sqlDataReader["Nom"].ToString();
                hebergement.Description = base.sqlDataReader["Description"].ToString();

                if (base.sqlDataReader["NomPhoto"].ToString() != null && base.sqlDataReader["NomPhoto"].ToString() != "") 
                {
                    hebergement.Photo = Constants.CheminPhoto + base.sqlDataReader["NomPhoto"].ToString();
                }

                hebergement.Type = base.sqlDataReader["NomHebergement"].ToString();  
                
                if (base.sqlDataReader["IdClient"].ToString() != null && base.sqlDataReader["IdClient"].ToString() != "")
                {
                    hebergement.IdClient = Convert.ToInt32(base.sqlDataReader["IdClient"]);
                }
                hebergement.PrixDeBase = Convert.ToDecimal(base.sqlDataReader["PrixDeBase"]);

                if(Convert.ToString(base.sqlDataReader["IdAdresse"]) != "" && Convert.ToString(base.sqlDataReader["NomAdresse"]) != "")
                {
                    //Gestion de l'ajout de l'adresse dans l hebergement
                    int IdAdresse = Convert.ToInt32(base.sqlDataReader["IdAdresse"]);
                    string NomAdresse = base.sqlDataReader["NomAdresse"].ToString();
                    string Numero = base.sqlDataReader["Numero"].ToString();
                    string Voie = base.sqlDataReader["Voie"].ToString();
                    string CodePostal = base.sqlDataReader["CodePostal"].ToString();
                    string Ville = base.sqlDataReader["Ville"].ToString();
                    Adresse AdresseHebergement = new Adresse(IdAdresse, NomAdresse, Numero, Voie, CodePostal, Ville);
                    hebergement.Adresse = AdresseHebergement;
                }
                if (Convert.ToString(base.sqlDataReader["IdClient"]) != null && Convert.ToString(base.sqlDataReader["IdClient"]) != "" && base.sqlDataReader["NomProprietaire"].ToString()!="")
                {
                    //Gestion de l'ajout du proprio dans l'hebergement
                    int IdProprio = Convert.ToInt32(base.sqlDataReader["IdClient"]);
                    string Nom = base.sqlDataReader["NomProprietaire"].ToString();
                    string Prenom = base.sqlDataReader["Prenom"].ToString();
                    string Email = base.sqlDataReader["Email"].ToString();
                    string Telephone = base.sqlDataReader["Telephone"].ToString();
                    Client Proprietaire = new Client();
                    Proprietaire.IdClient = IdProprio;
                    Proprietaire.Nom = Nom;
                    Proprietaire.Prenom = Prenom;
                    Proprietaire.Email = Email;
                    Proprietaire.Telephone = Telephone;
                    hebergement.Proprietaire = Proprietaire;
                }                  

                return hebergement;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
        public void InsertHebergement(string NomHebergement, int IdType, string Description, int IdClient, decimal PrixDeBase, string Numero, string Voie, string CodePostal, string Ville, string NomPhoto)
        {
            try
            {
                string sql = "sp_InsertHebergement";

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@NomHebergement", NomHebergement));
                sqlParameters.Add(new SqlParameter("@IdType", IdType));
                sqlParameters.Add(new SqlParameter("@Description", Description));
                sqlParameters.Add(new SqlParameter("@IdClient", IdClient));
                sqlParameters.Add(new SqlParameter("@PrixDeBase", PrixDeBase));
                sqlParameters.Add(new SqlParameter("@Numero", Numero));
                sqlParameters.Add(new SqlParameter("@Voie", Voie));
                sqlParameters.Add(new SqlParameter("@CodePostal", CodePostal));
                sqlParameters.Add(new SqlParameter("@Ville", Ville));
                sqlParameters.Add(new SqlParameter("@NomPhoto", NomPhoto));

                base.SetData(sql, sqlParameters);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRLoca
{
    public partial class Exemple_connection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Chaine de connection 
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=MRLoca;Integrated Security=True";

            //Objet pour se connecter
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //requete SQL
            string sqlString = "SELECT * FROM Hebergement";

            //Objet pour executer la requete
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            SqlDataReader sqlDataReader = null;
            try
            {
                //On se connecte à la bdd
                sqlConnection.Open();

                //On execute l'operation de SQL (dans ce cas) qui nous renvois un tableau
                //Les donnees sont stockéesdans un objet SqlDataReader
                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
            }
            List<Hebergement> ListeHebergement = null;
            //Creation d'une liste d'Hebergement si le reader contient au moins une ligne            
            if (sqlDataReader.HasRows)
            {
                ListeHebergement = new List<Hebergement>();
                while (sqlDataReader.Read())
                {
                    Hebergement hebergement = new Hebergement();
                    hebergement.IdHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);
                    hebergement.Nom = sqlDataReader["Nom"].ToString();
                    hebergement.Description = sqlDataReader["Description"].ToString();
                    hebergement.Photo = sqlDataReader["Photo"].ToString();
                    hebergement.Type = sqlDataReader["Nom"].ToString();
                    hebergement.IdClient = Convert.ToInt32(sqlDataReader["IdClient"]);
                    hebergement.IdAdresse = Convert.ToInt32(sqlDataReader["IdAdresse"]);
                    ListeHebergement.Add(hebergement);
                }

            }
            this.gvwHebergement.DataSource = ListeHebergement;
            this.gvwHebergement.DataBind();
            sqlDataReader.Close();
            sqlConnection.Close();

        }
    }
}
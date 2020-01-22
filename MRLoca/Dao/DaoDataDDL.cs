using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Dao
{
    public class DaoDataDDL : DataAccess
    {
        public DaoDataDDL() : base()
        {

        }
        /// <summary>
        /// Creer une liste de Data à insérer dans un this.ddd.dadasource
        /// </summary>
        /// <param name="value">Champs de la table que l'on souhaite mettre en value la la balise option</param>
        /// <param name="affichage">Champs de la table que l'on souhaite voir afficher dans la DDL</param>
        /// <param name="table">Table de la BDD</param>
        /// <param name="champConditionne">Champs de la table que l'on souhaite conditionner</param>
        /// <param name="condition">Conditiion appliquée au champs conditionné</param>
        /// <returns></returns>
        public List<DataDDL> GetDataDDL(string value, string affichage, string table,string champConditionne, string condition)
        {
            try
            {
                string sql = "SELECT " + value + "," + affichage + " FROM " + table;
                if (champConditionne != null && condition != null)
                {
                    sql += "WHERE " + champConditionne + " = " + condition;
                }
                //Execution de GetDataReader Erité de DataAccess
                base.GetDataReader(sql, null);

                //Declaration de Listehebergement
                List<DataDDL> listeDataDDL = null;

                //Creation d'une liste d'Hebergement si le reader contient au moins une ligne            
                if (base.sqlDataReader.HasRows)
                {
                    listeDataDDL = new List<DataDDL>();
                    DataDDL dataDDL = new DataDDL();
                    dataDDL.Value = "";
                    dataDDL.Affichage = table;
                    listeDataDDL.Add(dataDDL);
                    while (base.sqlDataReader.Read())
                    {
                        //Creer un nouvel hebergement
                        dataDDL = new DataDDL();
                        dataDDL.Value = base.sqlDataReader[value].ToString();
                        dataDDL.Affichage = base.sqlDataReader[affichage].ToString();

                        //Ajout dans la liste 
                        listeDataDDL.Add(dataDDL);
                    }
                }
                //Fermeture du datareader
                base.sqlDataReader.Close();
                //Fermeture de la bdd
                base.sqlConnection.Close();

                return listeDataDDL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
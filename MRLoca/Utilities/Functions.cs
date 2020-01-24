using MRLoca.Dao;
using MRLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace MRLoca.Utilities
{
    public class Functions
    {
        /// <summary>
        /// Insertion d'erreur dans la BDD
        /// </summary>
        /// <param name="ex">Exception généré par un Try/Catch</param>
        public static void AddError(Exception ex)
        {
            DaoFunctions daoFunctions = new DaoFunctions();
            daoFunctions.InsertMessageErreur(ex.Message);
        }

        /// <summary>
        /// Génération automatique de DDL
        /// </summary>
        /// <param name="dropDownList">this.ddlMaDDL</param>
        /// <param name="dataDDL">daoDataDDL.getDataDDL</param>
        /// <returns></returns>
        public static DropDownList GenerationDDL(DropDownList dropDownList, List<DataDDL> dataDDL)
        {
            dropDownList.DataSource = dataDDL;
            dropDownList.DataTextField = "Affichage";
            dropDownList.DataValueField = "Value";
            return dropDownList;
        }

        /// <summary>
        /// Génération d'un carousel via une liste d hebergement
        /// </summary>
        /// <returns>Code à insérer dans une Litéral - Retourne du string contenant l'ensemble du code HTML pour un Carrousel en Bootstrap</returns>
        public static string GenerationCarousel(List<Hebergement> ListeListeHebergement)
        {
            StringBuilder carousel = new StringBuilder();
            if (ListeListeHebergement != null && ListeListeHebergement.Count()>0)
            {
                
                carousel.AppendLine("<div id = 'carouselExampleIndicators' class='carousel slide' data-ride='carousel'>");
                carousel.AppendLine("<ol class='carousel-indicators'>");
                int i = 0;
                foreach (Hebergement item in ListeListeHebergement)
                {
                    if (i == 0)
                    {
                        carousel.AppendLine("<li data-target='#carouselExampleIndicators' data-slide-to='" + i + "' class='active'></li>");
                        i++;
                    }
                    else
                    {
                        carousel.AppendLine("<li data-target='#carouselExampleIndicators' data-slide-to='" + i + "'></li>");
                        i++;
                    }
                }
                carousel.AppendLine("</ol><div class='carousel-inner border shadow my-5 bg-white rounded'>");
                int j = 0;
                foreach (Hebergement item in ListeListeHebergement)
                {
                    if (j == 0)
                    {
                        carousel.AppendLine("<div class='carousel-item active'>");
                    }
                    else
                    {
                        carousel.AppendLine("<div class='carousel-item'>");
                    }
                    carousel.AppendLine(" <a href='DetailHebergement.aspx?id=" + item.IdHebergement + @"'><img Class='d-block w-100' src='" + item.Photo + @"' ID='imgPhoto" + j + @"' runat='server' /><div class='carousel-caption d-none d-md-block'><h5>" + item.Nom + "</h5></div></a></div>");
                    j++;
                }
                carousel.AppendLine("< a class='carousel-control-prev' href='#carouselExampleIndicators' role='button' data-slide='prev'><span class='carousel-control-prev-icon' aria-hidden='true'></span><span class='sr-only'>Previous</span></a><a class='carousel-control-next' href='#carouselExampleIndicators' role='button' data-slide='next'><span class='carousel-control-next-icon' aria-hidden='true'></span><span class='sr-only'>Next</span></a></div></div>");

            }
            return carousel.ToString();
        }

        /// <summary>
        /// Generation de ma liste d'hebergement
        /// </summary>
        /// <returns></returns>
        public static List<Hebergement> LoadHebergement()
        {
            DaoHebergement Daohebergement = new DaoHebergement();
            return Daohebergement.GetAllHebergements();
        }
    }
}
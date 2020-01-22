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
    public class function
    {
        public DropDownList GenerationDDL(DropDownList dropDownList, List<DataDDL> dataDDL)
        {
            dropDownList.DataSource = dataDDL;
            dropDownList.DataTextField = "Affichage";
            dropDownList.DataValueField = "Value";
            return dropDownList;
        }
        public string GenerationCarousel(List<Hebergement> ListeListeHebergement)
        {
            StringBuilder carousel = new StringBuilder();
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
                carousel.AppendLine(" <a href='DetailHebergement.aspx?id=" + item.IdHebergement + @"'><img Class='d-block w-100' src='" + item.Photo + @"' ID='imgPhoto" + j + @"' runat='server' /><div class='carousel-caption d-none d-md-block'><h5>"+item.Nom+"</h5></div></a></div>");
                j++;
            }
            carousel.AppendLine("< a class='carousel-control-prev' href='#carouselExampleIndicators' role='button' data-slide='prev'><span class='carousel-control-prev-icon' aria-hidden='true'></span><span class='sr-only'>Previous</span></a><a class='carousel-control-next' href='#carouselExampleIndicators' role='button' data-slide='next'><span class='carousel-control-next-icon' aria-hidden='true'></span><span class='sr-only'>Next</span></a></div></div>");
            return carousel.ToString();
        }
        public List<Hebergement> LoadHebergement()
        {
            DaoHebergement Daohebergement = new DaoHebergement();
            return Daohebergement.GetAllHebergements();
        }
        /// <summary>
        /// Permet de creer un SqlParametre à ajouter dans un SqlParaeter[]
        /// </summary>
        /// <param name="Nom">sqlParameter.ParameterName</param>
        /// <param name="value">sqlParameter.Value</param>
        /// <returns></returns>
        public SqlParameter AddSqlParameter(string Nom,object value)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = Nom;
            sqlParameter.Value = value;
            return sqlParameter;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Utilities
{
    public class Constants
    {
        // Chaine de connection BDD
        public const string StringConnection = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=MRLoca;Integrated Security=True";
           // @"Server=LOCALHOST\SQLEXPRESS;Database=MRLoca;User Id=sa;Password=123456;";
        public const string Client = "Client";
        public const string CheminPhoto = "Images/Upload/";
    }
}
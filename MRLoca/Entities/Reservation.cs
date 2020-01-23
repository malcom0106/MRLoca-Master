using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRLoca.Entities
{
    public class Reservation
    {
        public int IdReservation { set; get; }
        public int IdClient { set; get; }
        public int IdHebergement { set; get; }
        public DateTime DateReservation { set; get; }
        public DateTime DateDebut { set; get; }
        public DateTime DateFin { set; get; }
        public Reservation()
        {

        }

    }
}
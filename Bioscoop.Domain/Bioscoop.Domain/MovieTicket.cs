using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Domain
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        private int rowNr = seatRow;
        private int seatNr = seatNr;
        private bool isPremium = isPremiumReservation;

        public bool isPremiumTicket() { return isPremium; }

        public double getPrice() { return 0; }

        public string toString() { return ""; }
    }
}

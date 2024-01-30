namespace Bioscoop.Domain
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        private int rowNr = seatRow;
        private int seatNr = seatNr;
        private bool isPremium = isPremiumReservation;

        public bool isPremiumTicket() { return isPremium; }

        public double getPrice() { return 0; }

        public MovieScreening GetMovieScreening()
        {
            return movieScreening;
        }
        
        public string toString() { return "Row Nr: " + rowNr + ", seat Nr: " + seatNr + ", is premium: " + isPremium; }
    }
}

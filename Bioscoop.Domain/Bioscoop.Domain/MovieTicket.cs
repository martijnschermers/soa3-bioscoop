namespace Bioscoop.Domain
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        private readonly int rowNr = seatRow;
        private readonly int seatNr = seatNr;
        private readonly bool isPremium = isPremiumReservation;

        public bool IsPremiumTicket() { return isPremium; }

        public double GetPrice() { return movieScreening.getPricePerSeat(); }

        public MovieScreening GetMovieScreening()
        {
            return movieScreening;
        }

        public override string ToString() { return "Row Nr: " + rowNr + ", seat Nr: " + seatNr + ", is premium: " + isPremium; }
    }
}

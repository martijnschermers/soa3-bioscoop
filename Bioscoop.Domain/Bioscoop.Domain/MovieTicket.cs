namespace Domain
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        public bool IsPremiumTicket()
        {
            return isPremiumReservation;
        }

        public double GetPrice()
        {
            return movieScreening.GetPricePerSeat();
        }

        public MovieScreening GetMovieScreening()
        {
            return movieScreening;
        }

        public override string ToString()
        {
            return "Row Nr: " + seatRow + ", seat Nr: " + seatNr + ", is premium: " + isPremiumReservation;
        }
    }
}
namespace Domain
{
    public class MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        public double GetPricePerSeat()
        {
            return pricePerSeat;
        }

        public DateTime GetDateAndTime()
        {
            return dateAndTime;
        }

        public override string ToString()
        {
            return "Movie: " + movie + ", Screening date: " + dateAndTime + ", Price per seat: " + pricePerSeat + ".";
        }
    }
}
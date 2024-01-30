namespace Bioscoop.Domain
{
    public class MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        private DateTime dateAndTime = dateAndTime;
        private double pricePerSeat = pricePerSeat;
        private Movie movie = movie;

        public double getPricePerSeat() { return pricePerSeat; }

        public DateTime GetDateAndTime()
        {
            return dateAndTime;
        }

        public string toString() { return "Movie: " + movie + ", Screening date: " + dateAndTime + ", Price per seat: " + pricePerSeat + "." }
    }
}

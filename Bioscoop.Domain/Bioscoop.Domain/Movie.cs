namespace Domain
{
    public class Movie(string title)
    {
        private readonly List<MovieScreening> movieScreenings = new();

        public void AddScreaning(MovieScreening screening)
        {
            movieScreenings.Add(screening);
        }

        public List<MovieScreening> GetMovieScreenings()
        {
            return movieScreenings;
        }

        public override string ToString()
        {
            return title;
        }
    }
}
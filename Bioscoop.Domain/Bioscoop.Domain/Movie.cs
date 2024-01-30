using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Domain
{
    public class Movie(string title)
    {
        private string title = title;
        private List<MovieScreening> movieScreenings;

        public void addScreaning(MovieScreening screening) { }
        public List<MovieScreening> getMovieScreenings() { return movieScreenings; }

        public string toString() { return title; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class MovieAverageRating
    {
        public int Id {get; set;}
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
    }
}

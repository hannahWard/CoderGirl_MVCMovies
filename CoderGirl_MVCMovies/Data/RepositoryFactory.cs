using CoderGirl_MVCMovies.Views.MovieRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public static class RepositoryFactory
    {
        private static IMovieRatingRepository movieRatingRepository;
        

        public static IMovieRatingRepository GetMovieRatingRepository()
        {
            movieRatingRepository = new MovieRatingRepository();
            //if (movieRatingRepository == null)
            //{
                
            //}
                 
            
            
            // TODO: new up your implementation class here
            return movieRatingRepository;
        }
    }
}

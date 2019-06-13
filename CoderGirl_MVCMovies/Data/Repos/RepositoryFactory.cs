using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public static class RepositoryFactory
    {
        private static IRepository<MovieRating> movieRatingRepository;
        private static IRepository<Movie> movieRepository;
        private static IRepository<Director> directorRepository;

        private static MoviesDbContext context;


        public static IRepository<MovieRating> GetMovieRatingRepository()
        {
            if (movieRatingRepository == null)
                movieRatingRepository = new Repository<MovieRating>(context);
            return movieRatingRepository;
        }

        public static IRepository<Movie> GetMovieRepository()
        {
            if (movieRepository == null)
                movieRepository = new Repository<Movie>(context);
            return movieRepository;
        }

        public static IRepository<Director> GetDirectorRepository()
        {
            if (directorRepository == null)
                directorRepository = new Repository<Director>(context);
            return directorRepository;
        }
    }
}

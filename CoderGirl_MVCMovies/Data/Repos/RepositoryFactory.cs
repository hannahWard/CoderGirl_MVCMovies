using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class RepositoryFactory
    {
        private MoviesDbContext context;

        public RepositoryFactory(MoviesDbContext context)
        {
            this.context = context;
        }

        public IRepository<MovieRating> GetMovieRatingRepository()
        {
                return new Repository<MovieRating>(context);
        }

        public IRepository<Movie> GetMovieRepository()
        {
            return new Repository<Movie>(context);
        }

        public IRepository<Director> GetDirectorRepository()
        {
            return new Repository<Director>(context);
        }
    }
}

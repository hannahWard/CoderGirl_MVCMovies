using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : BaseRepository
    {
        static List<Movie> movies = new List<Movie>();
        static int nextId = 1;
        static IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public void Delete(int id)
        {
            movies.RemoveAll(m => m.Id == id);
        }

        public Movie GetById(int id)
        {
            Movie movie = movies.SingleOrDefault(m => m.Id == id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);
            return movie;
        }

        public override List<IModel> GetModels()
        {
            return movies.Select(movie => SetMovieRatings(movie))
                .Select(movie => SetDirectorName(movie)).ToList();
        }

        public int Save(Movie movie)
        {
            movie.Id = nextId++;
            movies.Add(movie);
            return movie.Id;
        }

        public void Update(Movie movie)
        {
            this.Delete(movie.Id);
            movies.Add(movie);
        }

        private Movie SetMovieRatings(Movie movie)
        {
            List<int> ratings = ratingRepository.GetModels()
                                                .Cast<MovieRating>()
                                                .Where(rating => rating.MovieId == movie.Id)
                                                .Select(rating => rating.Rating)
                                                .ToList();
            movie.Ratings = ratings;
            return movie;
        }

        private Movie SetDirectorName(Movie movie)
        {
            Director director = (Director)directorRepository.GetById(movie.DirectorId);
            movie.DirectorName = director.FullName;
            return movie;
        }
    }
}

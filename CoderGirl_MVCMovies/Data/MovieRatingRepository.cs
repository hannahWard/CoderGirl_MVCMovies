using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        static List<MovieRating> movies = new List<MovieRating>();
        static int nextId = 1;

        public void Delete(int id)
        {
            movies.RemoveAll(m => m.Id == id);
        }

        public MovieRating GetById(int id)
        {
            return movies.SingleOrDefault(m => m.Id == id);
        }

        public List<MovieRating> GetMovieRatings()
        {
            return movies;
        }

        public int Save(MovieRating movieRating)
        {
            movieRating.Id = nextId++;
            movies.Add(movieRating);
            return movieRating.Id;
        }

        public void Update(MovieRating movie)
        {
            this.Delete(movie.Id);
            movies.Add(movie);
        }

        public string GetMovieNameById(int id)
        {
            return movies.SingleOrDefault(m => m.Id == id).MovieName;
        }
    }
}

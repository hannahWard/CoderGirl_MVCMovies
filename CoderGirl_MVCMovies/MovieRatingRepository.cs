using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;

namespace CoderGirl_MVCMovies.Views.MovieRating
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        
        public decimal GetAverageRatingByMovieName(string movieName)
        {
            decimal rating = 0;
            foreach (var movie in Controllers.MovieController.movies)
            {
                if (movie.MovieName == movieName)
                {
                    double getAverage = movie.MovieRatings.Average();
                    rating = (decimal)Math.Round(getAverage);
                }
                else
                {
                    continue;
                }
            }

            return rating;
        }

        public List<int> GetIds()
        {
            List<int> getIds = new List<int>();
            foreach (var movie in Controllers.MovieController.movies)
            {
                getIds.Add(movie.Id);
            }
            return getIds;
        }

        public string GetMovieNameById(int id)
        {
            string name = null;
            foreach (var movie in Controllers.MovieController.movies)
            {
                if (id == movie.Id)
                {
                    name = movie.MovieName;
                }
                else
                {
                    continue;
                }
            }
            return name;
        }

        public int GetRatingById(int id)
        {
            int rating = 0;
            foreach (var movie in Controllers.MovieController.movies)
            {
                if (id == movie.Id)
                {
                    double getAverage = movie.MovieRatings.Average();
                    rating = (int)Math.Round(getAverage);
                }
                else
                {
                    continue;
                }
            }
            return rating;
        }

        public int SaveRating(string movieName, int rating)
        {
            if (String.IsNullOrEmpty(movieName) == false && rating != 0)
            {
                Movies movie = new Movies();
                movie.MovieName = movieName;
                movie.Id = Controllers.MovieController.nextIdToUse;
                movie.MovieRatings = new List<int>();
                movie.MovieRatings.Add(rating);
                Controllers.MovieController.movies.Add(movie);
                return movie.Id;
            }
            else return 0;
        }
    }
}

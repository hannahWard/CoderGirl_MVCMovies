using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Views.MovieRating
{
    public class MovieRatingRepository : Data.IMovieRatingRepository
    {
        public List<string> GetAverageRatingByMovieName(string movieName)
        {
            if (Controllers.MovieController.movies.ContainsValue(movieName))
            {
                foreach (var movieRating in Controllers.MovieRatingController.movieRatings)
                {
                    foreach (var movie in Controllers.MovieController.movies)
                    {
                        if (movieRating.Key == movie.Key)
                        {
                            string rating = movieRating.Value.ToString();
                            
                        }
                    }
                }
            }
            throw new NotImplementedException();
        }

        public List<int> GetIds()
        {
            throw new NotImplementedException();
        }

        public string GetMovieNameById(int id)
        {
            if (Controllers.MovieController.movies.TryGetValue(id, out string value))
            {
                return value;
            }
            else
            {
                return null;
            }
            
        }

        public string GetRatingById(int id)
        {
            if (Controllers.MovieRatingController.movieRatings.TryGetValue(id, out string value))
            {
                return value;
            }
            else
            {
                return null;
            }
            
        }

        public int SaveRating(string movieName, string rating)
        {
            
            if (String.IsNullOrEmpty(movieName) == false && String.IsNullOrEmpty(rating) == false)
            {
                Controllers.MovieRatingController.movieRatings.Add(Controllers.MovieRatingController.ratingNextIdToUse, rating);

                Controllers.MovieRatingController.ratingNextIdToUse++;
                return Controllers.MovieRatingController.ratingNextIdToUse - 1;
            }
            else
            {
                return 0;
            }

        }
    }
}

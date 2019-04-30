using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;

namespace CoderGirl_MVCMovies.Views.MovieRating
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        
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
                    name = movie.Name;
                }
                else
                {
                    continue;
                }
            }
            return name;
        }

        public int SaveRating(string movieName, int rating)
        {
            if (String.IsNullOrEmpty(movieName) == false && rating != 0)
            {
                Movie movie = new Movie();
                movie.Name = movieName;
                movie.Id = Controllers.MovieController.nextIdToUse++;
                movie.Rating = rating;
                Controllers.MovieController.movies.Add(movie);
                return movie.Id;
            }
            else return 0;
        }

        public int GetRatingById(int id)
        {
            var getRating = Controllers.MovieController.movies.Where(p => p.Id == id).Select(p => p.Rating).ToList();
            return getRating[0];
        }

        

        double IMovieRatingRepository.GetAverageRatingByMovieName(string movieName)
        {
            return Controllers.MovieController.movies.Where(p => p.Name == movieName).Select(p => p.Rating).Average();
        }
    }
}

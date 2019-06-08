using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRating
{
    public class MovieRatingListItemViewModel
    {
        public static List<MovieRatingListItemViewModel> GetMovieRatingList()
        {
            return RepositoryFactory.GetMovieRatingRepository()
                .GetModels()
                .Cast<Models.MovieRating>()
                .Select(rating => GetMovieRatingListItemFromDirector(rating))
                .ToList();
        }

        private static MovieRatingListItemViewModel GetMovieRatingListItemFromDirector(Models.MovieRating rating)
        {
            return new MovieRatingListItemViewModel
            {
                Id = rating.Id,
                MovieName = rating.MovieName,
                Rating = rating.Rating
            };
        }

        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        
    }
}

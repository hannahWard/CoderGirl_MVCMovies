using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieListItemViewModel
    {
        public static List<MovieListItemViewModel> GetMovieList()
        {
            return RepositoryFactory.GetMovieRepository()
                .GetModels()
                .Cast<Models.Movie>()
                .Select(director => GetMovieListItemFromMovie(director))
                .ToList();
        }

        private static MovieListItemViewModel GetMovieListItemFromMovie(Models.Movie movie)
        {
            return new MovieListItemViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                DirectorName = movie.DirectorName,
                Year = movie.Year,
                Ratings = RepositoryFactory.GetMovieRatingRepository().GetModels().Cast<Models.MovieRating>()
                                                .Where(rating => rating.MovieId == movie.Id)
                                                .Select(rating => rating.Rating)
                                                .ToList(),
        };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public List<int> Ratings { get; set; }

    }
}

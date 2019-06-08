using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRating
{
    public class MovieRatingEditViewModel
    {
        public static MovieRatingEditViewModel GetModel(int id)
        {
            Models.MovieRating rating = (Models.MovieRating)RepositoryFactory.GetMovieRatingRepository().GetById(id);
            return new MovieRatingEditViewModel
            {
                MovieName = rating.MovieName,
                Rating = rating.Rating

            };
        }

        public string MovieName { get; set; }
        public int Rating { get; set; }

        public void Persist(int id)
        {
            Models.MovieRating rating = new Models.MovieRating
            {
                Id = id,
                MovieName = this.MovieName,
                Rating = this.Rating,
            };
            RepositoryFactory.GetMovieRatingRepository().Update(rating);
        }
    }
}

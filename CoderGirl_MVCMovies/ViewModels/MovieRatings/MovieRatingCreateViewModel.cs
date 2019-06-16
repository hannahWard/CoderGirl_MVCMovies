using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewsModels.MovieRatings
{
    public class MovieRatingCreateViewModel
    {
        private string ratings = "12345";
        private readonly RepositoryFactory repositoryFactory;

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public SelectList Ratings { get { return GetRatings(); } }

        public MovieRatingCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        private SelectList GetRatings()
        {
            var ratingSelectListItems = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString()));
            return new SelectList(ratingSelectListItems);
        }

        internal void Persist()
        {
            MovieRating rating = new MovieRating
            {
                MovieId = this.MovieId,
                Rating = this.Rating
            };
            repositoryFactory.GetMovieRatingRepository().Save(rating);
        }
    }
}

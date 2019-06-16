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

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public SelectList Ratings { get { return GetRatings(); } }

        private SelectList GetRatings()
        {
            var ratingSelectListItems = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString()));
            return new SelectList(ratingSelectListItems);
        }
    }
}

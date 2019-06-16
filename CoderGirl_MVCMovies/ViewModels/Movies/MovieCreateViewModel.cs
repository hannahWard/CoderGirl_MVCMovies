using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieCreateViewModel
    {

        public string Name { get; set; }
        public int DirectorId { get; set; }
        public SelectList Directors { get; set; }
        public int Year { get; set; }

        public MovieCreateViewModel(MoviesDbContext context)
        {
            this.Directors = GetDirectorList(context);
        }

        public void Persist(MoviesDbContext context)
        {
            Models.Movie movie = new Models.Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                Year = this.Year
            };
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        internal void ResetDirectorList(MoviesDbContext context)
        {
           this.Directors = GetDirectorList(context);
        }

        private SelectList GetDirectorList(MoviesDbContext context)
        {
            return new SelectList(context.Directors, "Id", "FullName", this.DirectorId);
        }
    }
}

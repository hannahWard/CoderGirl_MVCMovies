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
    public class MovieEditViewModel
    {
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public SelectList Directors { get; set; }
        public int Year { get; set; }

        public MovieEditViewModel() { }

        public MovieEditViewModel(int id, MoviesDbContext context)
        {
            Movie movie=context.Movies.Find(id);
            this.DirectorId = movie.DirectorId;
            this.Year = movie.Year;
            this.Name = movie.Name;
            this.Directors = GetDirectorList(context);
        }

        public void Persist(int id, MoviesDbContext context)
        {
            Models.Movie movie = new Models.Movie
            {
                Id = id,
                Name = this.Name,
                DirectorId = this.DirectorId,
                Year = this.Year
            };
            context.Add(movie);
            context.SaveChanges();
        }

        private SelectList GetDirectorList(MoviesDbContext context)
        {
            return new SelectList(context.Directors, "Id", "FullName", this.DirectorId);
        }

        internal void ResetDirectorList(MoviesDbContext context)
        {
            this.Directors = GetDirectorList(context);
        }
    }
}


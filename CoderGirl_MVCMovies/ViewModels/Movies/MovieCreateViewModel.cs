using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieCreateViewModel
    {
        [Required(ErrorMessage ="Some customer error message")]
        public string Name { get; set; }

        [Display(Name="Select Director")]
        public int DirectorId { get; set; }
        public SelectList Directors { get; set; }

        [Required]
        [Range(1887, 2020, ErrorMessage ="Error")]
        [Display(Name="Year")]
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

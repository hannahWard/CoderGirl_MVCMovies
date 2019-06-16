using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieCreateViewModel
    {
        private readonly RepositoryFactory repositoryFactory;

        public string Name { get; set; }
        public int DirectorId { get; set; }
        public SelectList Directors { get; set; }
        public int Year { get; set; }

        public MovieCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.Directors = GetDirectorList();
        }

        public void Persist()
        {
            Models.Movie movie = new Models.Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                Year = this.Year
            };
            repositoryFactory.GetMovieRepository().Save(movie);
        }

        private SelectList GetDirectorList()
        {
            var directors = repositoryFactory.GetDirectorRepository()
                .GetModels();
            return new SelectList(directors, "Id", "FullName", this.DirectorId);
        }
    }
}

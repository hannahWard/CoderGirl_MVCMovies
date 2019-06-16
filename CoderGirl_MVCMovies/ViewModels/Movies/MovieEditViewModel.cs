using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieEditViewModel
    {
        private readonly RepositoryFactory repositoryFactory;

        public string Name { get; set; }
        public int DirectorId { get; set; }
        public SelectList Directors { get { return GetDirectorList(); } }
        public int Year { get; set; }

        public MovieEditViewModel(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public MovieEditViewModel(int id)
        {
            Movie movie=repositoryFactory.GetMovieRepository().GetById(id);
            this.DirectorId = movie.DirectorId;
            this.Year = movie.Year;
            this.Name = movie.Name;
        }

        public void Persist(int id)
        {
            Models.Movie movie = new Models.Movie
            {
                Id = id,
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


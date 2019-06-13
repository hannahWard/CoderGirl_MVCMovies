using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
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
        public List<Director> Directors { get; set; }
        public int Year { get; set; }

        public MovieEditViewModel(int id)
        {
            Movie movie=RepositoryFactory.GetMovieRepository().GetById(id);
            this.DirectorId = movie.DirectorId;
            this.Year = movie.Year;
            this.Name = movie.Name;
            this.Directors = GetDirectorList();
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
            RepositoryFactory.GetMovieRepository().Save(movie);
        }

        private List<Director> GetDirectorList()
        {
            return RepositoryFactory.GetDirectorRepository()
                .GetModels();
        }
    }
}


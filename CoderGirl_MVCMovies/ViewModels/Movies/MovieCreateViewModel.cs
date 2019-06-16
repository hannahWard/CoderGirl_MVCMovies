using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
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
        public List<Director> Directors { get; set; }
        public int Year { get; set; }

        public MovieCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.Directors = GetDirectorList();
            this.repositoryFactory = repositoryFactory;
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

        private List<Director> GetDirectorList()
        {
            return repositoryFactory.GetDirectorRepository()
                .GetModels()
                .Cast<Director>()
                .ToList();
        }
    }
}

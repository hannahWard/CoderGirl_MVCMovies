using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Directors
{
    public class DirectorEditViewModel
    {
        public static DirectorEditViewModel GetModel(int id)
        {
            Director director = (Director)RepositoryFactory.GetDirectorRepository().GetById(id);
            return new DirectorEditViewModel
            {
                FirstName = director.FirstName,
                LastName = director.LastName,
                BirthDate = director.BirthDate,
                Nationality = director.Nationality
            };
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }

        public void Persist(int id)
        {
            Director director = new Director
            {
                Id = id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Nationality = this.Nationality
            };
            RepositoryFactory.GetDirectorRepository().Update(director);
        }
    }
}

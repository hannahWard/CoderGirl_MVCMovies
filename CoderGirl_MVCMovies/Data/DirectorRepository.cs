using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class DirectorRepository : IDirectorRepository
    {
        static List<Director> directors = new List<Director>();
        static int nextId = 1;

        public List<Director> GetDirectors()
        {
            return directors;
        }

        public int Save(Director director)
        {
            director.Id = nextId++;
            //string formatBirthDate = director.BirthDate.ToShortDateString();
            //director.BirthDate = DateTime.Parse(formatBirthDate);
            directors.Add(director);
            return director.Id;
        }
    }


}

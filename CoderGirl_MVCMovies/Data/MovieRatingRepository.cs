﻿using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        private static List<MovieRating> movieRatings = new List<MovieRating>();
        private static int nextId = 1;
        private static IMovieRespository movieRespository = RepositoryFactory.GetMovieRepository();

        public void Delete(int id)
        {
            movieRatings.RemoveAll(r => r.Id == id);
        }

        public MovieRating GetById(int id)
        {
            return movieRatings.SingleOrDefault(r => r.Id == id);
        }

        public List<MovieRating> GetMovieRatings()
        {
            return movieRatings;
        }

        public int Save(MovieRating movieRating)
        {
            movieRating.Id = nextId;
            //movieRating.MovieId = nextId++;
            movieRatings.Add(movieRating);
            return movieRating.Id;
        }

        public void Update(MovieRating movieRating)
        {
            this.Delete(movieRating.Id);
            movieRatings.Add(movieRating);
        }
    }
}

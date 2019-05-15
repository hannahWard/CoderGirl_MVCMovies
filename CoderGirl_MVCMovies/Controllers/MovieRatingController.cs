using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRespository movieRespository = RepositoryFactory.GetMovieRepository();
        private int nextId = 1;

       public IActionResult Index()
        {
            List<MovieRating> movieRatings = ratingRepository.GetMovieRatings();

            return View(movieRatings);
            
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            Movie movie = movieRespository.GetById(id);
            MovieRating movieRating = new MovieRating();
            
            movieRating.MovieName = movie.Name;
            
            
            
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            
            Movie movie = movieRespository.GetById(movieRating.Id);
            movieRating.MovieId = movie.Id;
            //movieRating.Id = nextId++;
            ratingRepository.Save(movieRating);
            //Movie movie = new Movie();
            //movie.Name = movieRating.MovieName;
            //movie.Id = movieRating.MovieId;
            //movieRespository.SetMovieRatings(movie);
            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = ratingRepository.GetById(id);
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            ratingRepository.Update(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ratingRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
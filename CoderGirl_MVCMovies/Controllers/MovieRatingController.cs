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
       private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRespository movieRespository = RepositoryFactory.GetMovieRepository();

       public IActionResult Index()
        {
            List<MovieRating> movies = repository.GetMovieRatings();
            return View(movies);
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = movieRespository.GetMovies();
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            ViewBag.Movies = movieRespository.GetMovies();
            MovieRating movie = new MovieRating();
            movie.MovieName = movieName;
            movie.Rating = rating;
            repository.Save(movie);

            //return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.Movie = movieName;
            ViewBag.Rating = rating;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movie = repository.GetById(id);
            ViewBag.MovieName = movie.MovieName;
            ViewBag.Id = id;
            return View();
        }


        [HttpPost]
        public IActionResult Edit(int id, MovieRating movie)
        {
            movie.Id = id;
            movie.MovieName = repository.GetMovieNameById(id);
            repository.Update(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
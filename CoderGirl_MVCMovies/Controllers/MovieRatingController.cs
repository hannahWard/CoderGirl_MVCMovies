using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();

        
        List<Movie> movies = Controllers.MovieController.movies;
        
        



        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.Movies = movies;
            return View();
        }

         
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = movies;
            
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(string movieName, int rating)
        {
            ViewBag.Name = movieName;
            ViewBag.Rating = rating;

            Movie movie = new Movie();
            movie.Name = movieName;
            movie.Rating = rating;
            movie.Id = Controllers.MovieController.nextIdToUse++;
            movies.Add(movie);

            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        

        [HttpGet]
        public IActionResult Details(string movieName, int rating)
        {
            
            ViewBag.MovieName = movieName;
            ViewBag.MovieRating = rating;
            
            return View();
        }
    }
}
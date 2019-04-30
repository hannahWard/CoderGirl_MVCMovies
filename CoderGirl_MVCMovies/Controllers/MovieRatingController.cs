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

        // TODO: Save the movie/rating in the MovieRatingRepository before redirecting to the Details page
        // TODO: Redirect passing only the id of the created movie/rating
        [HttpPost]
        public IActionResult Create(string movieName, int rating)
        {
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
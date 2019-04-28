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

        public static Dictionary<int, string> movieRatings = new Dictionary<int, string>();
        public static int ratingNextIdToUse = 1;


        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.MovieRatings = movieRatings;
            ViewBag.Movies = MovieController.movies;
            return View();
        }

         
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = MovieController.movies;
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            movieRatings.Add(ratingNextIdToUse, rating);
            ratingNextIdToUse++;
            int movieId = ratingNextIdToUse - 1;
            return RedirectToAction(actionName: nameof(Details), routeValues: movieId);
            
        }

        
        [HttpGet]
        public IActionResult Details(int movieId)
        {
            movieId = ratingNextIdToUse - 1;
            ViewBag.MovieRatings = movieRatings;
            ViewBag.Movies = MovieController.movies;
            ViewBag.Id = movieId;

            return View();
        }
    }
}
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

        //public static Dictionary<int, List<string>> movieRatings = new Dictionary<int, List<string>>();
        public static int index = 0;
        public static int rating = 3;
        //public static int ratingNextIdToUse = 1;
        List<Movies> movies = Controllers.MovieController.movies;
        
        //var x = Controllers.MovieController.movies:
        //List<Movies> movies = new List<Movies>();
        //Movies eachMovie = new Movies();



        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.MovieRatings = movies;
            ViewBag.Movies = movies;
            return View();
        }

         
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = movies;
            //ViewBag.MovieName = Controllers.MovieController.eachMovie.MovieName;
            
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(string movieName, int rating)
        {
            Movies movie = new Movies();
            movieName = movie.MovieName;
            movie.MovieName = movieName;
            movie.MovieRatings = new List<int>();
            movie.MovieRatings.Add(rating);
            movie.Id = Controllers.MovieController.nextIdToUse;
            movies.Add(movie);
            //movieRatings.Add(ratingNextIdToUse, rating);
            //movieName = Controllers.MovieController.eachMovie.MovieName;
            //Controllers.MovieController.eachMovie.MovieRatings = new List<int>();
            //this.Controllers.MovieController.eachMovie.MovieRatings = new List<int>();
            //Controllers.MovieController.eachMovie.MovieRatings.Add(rating);
            //Controllers.MovieController.eachMovie.Id = ratingNextIdToUse++;
            //Controllers.MovieController.movies.Add(Controllers.MovieController.eachMovie);
            
            return RedirectToAction(actionName: nameof(Details), routeValues: movie.Id);
            
        }

        
        [HttpGet]
        public IActionResult Details(string movieName, int rating)
        {
            foreach (var movie in movies)
            {
                movie.MovieName = movieName;
                double getAverage = movie.MovieRatings.Average();
                rating = (int)Math.Round(getAverage);
                ViewBag.MovieName = movie.MovieName;
                ViewBag.MovieRating = rating;
            }

            //Movies movie = new Movies();
            //double getAverage = movie.MovieRatings.Average();
            //rating = (int)Math.Round(getAverage);
            
            //movieName = movie.MovieName;
            //this.movie.MovieRatings = new List<int>();
            //double getAverage = movie.MovieRatings.Average();
            //rating = (int)Math.Round(getAverage);
            //ViewBag.MovieName = movie.MovieName;
            //ViewBag.MovieRating = rating;
            

            return View();
        }
    }
}
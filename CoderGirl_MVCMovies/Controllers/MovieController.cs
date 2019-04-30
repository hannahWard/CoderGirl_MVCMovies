using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;





namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        
        public static int nextIdToUse = 1; //increment at the proper time
        public static List<Movie> movies = new List<Movie>();
        public static Movie eachMovie = new Movie();
        


        public IActionResult Index()
        {
            ViewBag.Movies = movies;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movie)
        {
            Movie eachMovie = new Movie();
            eachMovie.Name = movie;
            eachMovie.Id = nextIdToUse;
            
            movies.Add(eachMovie);
            nextIdToUse++;

            
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
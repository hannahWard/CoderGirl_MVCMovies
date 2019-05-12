using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;

//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;





namespace CoderGirl_MVCMovies.Controllers
{

    

    public class MovieController : Controller
    {

        //ChromeDriver driver;

        public static IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();
        private static int nextIdToUse = 1; 

        public IActionResult Index()
        {

             
        //private const string BASE_URL = "http://localhost:59471";
        //ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));


            List<Movie> movies = movieRepository.GetMovies();
            return View(movies);


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieRepository.Save(movie);
            
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetById(id);
            movie.Id = id;
            movieRepository.Update(movie);
            return View("Edit", movie);
        }


        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            //since id is not part of the edit form, it isn't included in the model, thus it needs to be set from the route value
            //there are alternative patterns for doing this - for one, you could include the id in the form but make it hidden
            //feel free to experiment - the tests wont' care as long as you preserve the id correctly in some manner
            movie.Id = id; 
            movieRepository.Update(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
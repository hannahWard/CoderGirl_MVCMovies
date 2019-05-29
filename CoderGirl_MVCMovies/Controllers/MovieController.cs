using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        static IRepository movieRepository = RepositoryFactory.GetMovieRepository();
        static IRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetModels().Cast<Movie>().ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Directors = directorRepository.GetModels().Cast<Director>().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (String.IsNullOrWhiteSpace(movie.Name))
            {
                ModelState.AddModelError("Name", "Name must be included");
            }

            if (movie.Year < 1888 || movie.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Not a valid year");
            }

            if (ModelState.ErrorCount > 0)
            {
                ViewBag.Directors = directorRepository.GetModels().Cast<Director>().ToList();
                return View(movie);
            }

            movieRepository.Save(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = (Movie)movieRepository.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            
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
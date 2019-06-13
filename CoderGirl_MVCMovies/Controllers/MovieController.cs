using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        static IRepository<Movie> movieRepository = RepositoryFactory.GetMovieRepository();
        static IRepository<Director> directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetModels();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            MovieCreateViewModel model = new MovieCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Name must be included");
            }
            if(model.Year < 1888 || model.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Year is not valid");
            }

            if(ModelState.ErrorCount > 0)
            {
                return View(model);
            }

            model.Persist();
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {            
            return View(new MovieEditViewModel(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieEditViewModel movie)
        {
            movie.Persist(id);
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
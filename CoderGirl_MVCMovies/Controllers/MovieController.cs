using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public MovieController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            List<MovieListItemViewModel> movies = MovieListItemViewModel.GetMovies(repositoryFactory);
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            MovieCreateViewModel model = new MovieCreateViewModel(repositoryFactory);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
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
            if (!ModelState.IsValid)
                return View(movie);

            movie.Persist(id, repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repositoryFactory.GetMovieRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
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
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Create(int movieId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int movieId, MovieRating movieRating)
        {

            return RedirectToAction(controllerName: nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {

            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id, RepositoryFactory respositoryFactory)
        {
            respositoryFactory.GetMovieRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
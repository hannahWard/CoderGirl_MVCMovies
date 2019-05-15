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
        public static IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();
        public static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetMovies();
            List<MovieAverageRating> averageRatings = new List<MovieAverageRating>();
            foreach(var movie in movies)
            {
                MovieAverageRating eachAverageRating = new MovieAverageRating();
                eachAverageRating.Id = movie.Id;
                eachAverageRating.AverageRating = movieRepository.GetAverageRatingByMovieName(movie.Name);
                eachAverageRating.NumberOfRatings = movieRepository.CountRatings(movie);
                averageRatings.Add(eachAverageRating);
            }
            ViewBag.AverageRatings = averageRatings;
            
            

            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Directors = directorRepository.GetDirectors();
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
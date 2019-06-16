using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        private readonly RepositoryFactory repositoryFactory;

        public DirectorController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Director> directors = repositoryFactory.GetDirectorRepository().GetModels().Cast<Director>().ToList();
            return View(directors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            repositoryFactory.GetDirectorRepository().Save(director);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
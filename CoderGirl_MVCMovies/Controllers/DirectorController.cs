using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.Directors;
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
            List<DirectorListItemViewModel> directors = DirectorListItemViewModel.GetDirectors(repositoryFactory);
            return View(directors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DirectorCreateViewModel director)
        {
            director.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
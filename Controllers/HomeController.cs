using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//The main controller that controls the views being shown and the transfer of data.
namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieInsert(MovieResponse movie)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddMovie(movie);

                return View("Confirmation", movie);
            }
            else
            {
                return View();
            }
        }

        public IActionResult MovieList()
        {
            return View(TempStorage.Movies.Where(movie => movie.Title!="Independence Day"));
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
        private MovieListContext context { get; set; }
        public HomeController(MovieListContext con)
        {
            context = con;
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
                context.Movies.Add(movie);
                context.SaveChanges();

                return View("Confirmation", movie);
            }
            else
            {
                return View();
            }
        }

        //This will pull the same form as earlier, but altered to be an edit form. Wil ltake in the data from the movie object they are changing
        [HttpGet]
        public IActionResult MovieEdit(MovieResponse movie)
        {
            return View(context.Movies.Where(m => m == movie).FirstOrDefault());
        }

        //This posts the update to the database for the particular movie object
        [HttpPost]
        public IActionResult MovieEditPost(MovieResponse movie)
        {

            if (ModelState.IsValid)
            {
                context.Movies.Update(movie);
                context.SaveChanges();

                return View("MovieList", context.Movies.Where(movie => movie.Title != "Independence Day"));
            }
            else
            {
                return View("MovieEdit", context.Movies.Where(m => m == movie).FirstOrDefault());
            }
        }

        [HttpPost]
        public IActionResult MovieRemove(MovieResponse movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();

            return View("MovieList", context.Movies.Where(movie => movie.Title != "Independence Day"));
        }
        
        public IActionResult MovieList()
        {
            return View(context.Movies.Where(movie => movie.Title!="Independence Day"));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyExerciseOne.Models;
using VidlyExerciseOne.ViewModels;

namespace VidlyExerciseOne.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> moviesList = new List<Movie>()
            {
                new Movie {Name = "Wall-E" },
                new Movie {Name = "Harry Potter" },
                new Movie {Name = "Home Alone" }
            };
            MoviesViewModel moviesVM = new MoviesViewModel()
            {
                MoviesList = moviesList
            };
            return View(moviesVM);
        }
    }
}
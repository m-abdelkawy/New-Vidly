using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyExerciseOneSolution.Models;
using VidlyExerciseOneSolution.ViewModels;

namespace VidlyExerciseOneSolution.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = GetMovies();
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie{Id = 1, Name = "Harry Potter"},
                new Movie{Id = 2, Name = "Wall-E"},
                new Movie{Id = 3, Name = "Brave Heart"}
            };
        }

        public ActionResult Random()
        {
            Movie movie = new Movie { Id = 1, Name = "Pay It Forward" };
            List<Customer> customers = new List<Customer>()
            {
                new Customer{Name = "Ashraf Fouad"},
                new Customer{Name = "Hussein Salama"}
            };
            RandomMovieViewModel movieVM = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(movieVM);
        }
    }
}
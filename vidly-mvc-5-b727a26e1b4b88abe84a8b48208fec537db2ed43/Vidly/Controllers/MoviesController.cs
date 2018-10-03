using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Linq;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _ctx;
        public MoviesController()
        {
            _ctx = new ApplicationDbContext();
        }
        public ViewResult Index()
        {
            //var movies = GetMovies();
            //Deferred Execution
            IEnumerable<Movie> movies = _ctx.Movies.Include(m => m.Genre).ToList();

            return View(movies);    
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult MovieDetails(int id)
        {
            Movie movie = _ctx.Movies.Include(c => c.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}
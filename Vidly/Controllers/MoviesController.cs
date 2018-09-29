using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //GET: Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(string.Format("PageIndex = {0}, sortBy = {1}", pageIndex, sortBy));
        }

        // GET: Movies/random
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };

            List<Customer> customerList = new List<Customer>()
            {
                new Customer {Name = "Ahmed" },
                new Customer {Name = "Ali" }
            };

            MovieViewModel movieVm = new MovieViewModel()
            {
                Movie = movie,
                CustomerList = customerList
            };
            return View(movieVm);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id {id}");
        }

        [Route("Movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
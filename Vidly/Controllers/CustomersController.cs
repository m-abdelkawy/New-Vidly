using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            Customer customer = new Customer() { Name = "Maher" };

            List<Movie> moviesList = new List<Movie>()
            {
                new Movie {Name = "Wall-E" },
                new Movie {Name = "Harry Potter" }
            };

            CustomerViewModel customerVM = new CustomerViewModel()
            {
                Customer = customer,
                MoviesList = moviesList
            };
            if (!id.HasValue)
            {
                return View(customerVM);
            }
            else
            {
                return Content($"{customerVM.MoviesList[Convert.ToInt32(id)].Name}");
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using VidlyExerciseOneSolution.Models;

namespace VidlyExerciseOneSolution.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _ctx;
        public CustomersController()
        {
            _ctx = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //IEnumerable<Customer> customers = GetCustomers();
            IEnumerable<Customer> customers = _ctx.Customers;
            return View(customers);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id = 1, Name = "Ahmed Ali"},
        //        new Customer{Id = 2, Name = "Mohammed hammam"},
        //        new Customer{Id = 3, Name = "Mohammed Abdelkawy"}
        //    };
        //}

        public ActionResult Details(int id)
        {
            //Customer customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            Customer customer = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}
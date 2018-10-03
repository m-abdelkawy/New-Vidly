using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        public ActionResult New()
        {
            IEnumerable<MembershipType> membershipTypes = _ctx.MembershipTypes;
            NewCustomerViewModel customerViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(customerViewModel);
        }
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            IEnumerable<Customer> customers = _ctx.Customers.Include(c => c.MembershipType).ToList(); 
            //Deferred execution - .ToList = Immediate execution

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            Customer customer = _ctx.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Williams" }
        //    };
        //}
    }
}
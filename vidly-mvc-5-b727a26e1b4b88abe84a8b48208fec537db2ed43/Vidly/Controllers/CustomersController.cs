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
            CustomerFormViewModel customerViewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {//Model Binding: Binding customerViewModelor Customer data from request

            if (!ModelState.IsValid)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _ctx.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                _ctx.Customers.Add(customer);
            else
            {
                Customer customerInDB = _ctx.Customers.Single(c => c.Id == customer.Id);

                //1st update method -- updates the model properties based on the key-value pairs in the request data
                //it updates all properties -- this method opens security holes in the application
                //a malicious software could add new key-value pairs to the request data
                /*TryUpdateModel(customerInDB);*/
                //2nd update method -- manually updating properties
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _ctx.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            IEnumerable<Customer> customers = _ctx.Customers.Include(c => c.MembershipType).ToList(); 
            //Deferred execution - .ToList = Immediate execution

            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            CustomerFormViewModel customerViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _ctx.MembershipTypes.ToList()
            };
            return View("CustomerForm", customerViewModel);
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
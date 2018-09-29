using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyExerciseOne.Models;
using VidlyExerciseOne.ViewModels;

namespace VidlyExerciseOne.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        //[Route("Customers/Details")]
        public ActionResult Details(int? id)
        {
            List<Customer> customerList = new List<Customer>()
            {
                new Customer {Name = "Ahmed Ali" },
                new Customer {Name = "Mohammed Abdelkawy" },
                new Customer {Name = "Mohammed Adel" }
            };
            CustomersViewModel customerVM;
            if (!id.HasValue)
            {
                customerVM = new CustomersViewModel()
                {
                    CustomersList = customerList
                };
            }
            else
            {
                customerVM = new CustomersViewModel()
                {
                    CustomersList = new List<Customer>()
                    {
                        customerList[Convert.ToInt32(id)]
                    }
                };
            }
            ViewBag.Id = id;
            return View(customerVM);
        }
    }
}
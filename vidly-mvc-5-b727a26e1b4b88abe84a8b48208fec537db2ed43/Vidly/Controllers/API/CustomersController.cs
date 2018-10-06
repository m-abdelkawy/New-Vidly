using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _ctx;
        public CustomersController()
        {
            _ctx = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _ctx.Customers;
        }

        //GET /api/customers/1
        public Customer GetCustomerById(int id)
        {
            Customer customer = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
            return customer;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdteCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Customer customerInDb = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _ctx.SaveChanges();
        }

        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            Customer customerInDb = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _ctx.Customers.Remove(customerInDb);
            _ctx.SaveChanges();
        }
    }
}

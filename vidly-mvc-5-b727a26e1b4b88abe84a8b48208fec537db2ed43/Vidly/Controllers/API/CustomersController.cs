using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _ctx.Customers.Include(c => c.MembershipType).Select(AutoMapper.Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomerById(int id)
        {
            Customer customer = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(AutoMapper.Mapper.Map<Customer, CustomerDto>(customer));
        }
        //public CustomerDto GetCustomerById(int id)
        //{
        //    Customer customer = _ctx.Customers.SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return AutoMapper.Mapper.Map<Customer, CustomerDto>(customer);
        //}

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            Customer customer = AutoMapper.Mapper.Map<CustomerDto, Customer>(customerDto);
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        //public CustomerDto CreateCustomer(CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = AutoMapper.Mapper.Map<CustomerDto, Customer>(customerDto);
        //    _ctx.Customers.Add(customer);
        //    _ctx.SaveChanges();

        //    customerDto.Id = customer.Id;

        //    return customerDto;
        //}

        //PUT /api/customers/1
        [HttpPut]
        public void UpdteCustomer(int id, CustomerDto customerDto)
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

            AutoMapper.Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            //No need for them since we used Mapper Class
            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

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

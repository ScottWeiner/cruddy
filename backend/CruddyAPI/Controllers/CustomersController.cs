using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CruddyAPI.Context;
using CruddyAPI.Context.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using CruddyAPI.Context.Repositories;

namespace CruddyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersRepository _repo;
        public CustomersController(CustomersRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")] //api/customers
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _repo.GetAllCustomers();

            if (customers == null)
            {
                return BadRequest("Oopsies, there is an issue");
            }

            return Ok(customers);
        }

        [HttpGet("{id:int}")] //api/customers/2
        public async Task<ActionResult> GetCustomer(int id)
        {
            var customer = await _repo.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return BadRequest("Oopsies, there is an issue");
            }

            return Ok(customer);
        }


    }
}
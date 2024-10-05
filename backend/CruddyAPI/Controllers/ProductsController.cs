using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruddyAPI.Context;
using CruddyAPI.Context.Entities;
using CruddyAPI.Context.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SQLitePCL;

namespace CruddyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ProductsRepository _repo;
        public ProductsController(ProductsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")] //api/products
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _repo.GetAllProducts();

            if (products == null)
            {
                return BadRequest("Oopsies, there is an issue");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}")] //api/products/2
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest("Oopsies, there is an issue");
            }

            return Ok(product);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruddyAPI.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CruddyAPI.Context.Repositories
{
    public class ProductsRepository(StoreContext context)
    {
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }
    }
}
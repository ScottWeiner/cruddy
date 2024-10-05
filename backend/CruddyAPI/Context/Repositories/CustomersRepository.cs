using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruddyAPI.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CruddyAPI.Context.Repositories
{
    public class CustomersRepository(StoreContext context)
    {
        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            context.Customers.Remove(customer);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await context.Customers.ToListAsync();
        }
    }
}
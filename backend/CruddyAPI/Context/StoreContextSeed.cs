using System.Reflection;
using System.Text.Json;
using CruddyAPI.Context;
using CruddyAPI.Context.Entities;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync(path + @"/Context/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products == null) return;

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }

        if (!context.Customers.Any())
        {
            var customersData = await File.ReadAllTextAsync(path + @"/Context/SeedData/customers.json");
            var customers = JsonSerializer.Deserialize<List<Customer>>(customersData);

            if (customers == null) return;
            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }
    }
}
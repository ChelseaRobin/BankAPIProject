using BankAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Models
{
    public static class PopulateCustomers
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BankContext(serviceProvider.GetRequiredService<DbContextOptions<BankContext>>()))
            {

                var customers = new Customer[] 
                {
                        new Customer(){ CustomerId = 1, Name = "arisha barron" },
                        new Customer(){ CustomerId = 2, Name = "branden gibson" },
                        new Customer(){ CustomerId = 3, Name = "rhonda church" },
                        new Customer(){ CustomerId = 4, Name = "georgina hazel" }
                };

                context.Customers.AddRange(customers);

                await context.SaveChangesAsync();
               
            }
        }
    }
}

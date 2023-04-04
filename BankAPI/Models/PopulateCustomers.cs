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

                var customers = new CustomerModel[] 
                {
                        new CustomerModel(){ CustomerId = 1, Name = "arisha barron" },
                        new CustomerModel(){ CustomerId = 2, Name = "branden gibson" },
                        new CustomerModel(){ CustomerId = 3, Name = "rhonda church" },
                        new CustomerModel(){ CustomerId = 4, Name = "georgina hazel" }
                };

                context.Customers.AddRange(customers);

                await context.SaveChangesAsync();
               
            }
        }
    }
}

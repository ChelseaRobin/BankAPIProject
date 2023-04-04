using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

namespace BankAPI.Models;

public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options)
    : base(options)
    {
    }

    public DbSet<AccountModel> Accounts { get; set; } = null!;
    public DbSet<CustomerModel> Customers { get; set; } = null!;
    public DbSet<TransactionsModel> TransactionsModel { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) //specifies tables and their relationships
    {
        modelBuilder.Entity<CustomerModel>()
                    .HasMany(c => c.AccountsList)
                    .WithOne(a => a.Customer);

        modelBuilder.Entity<AccountModel>()
                    .HasMany(a => a.TransactionsList);

        modelBuilder.Seed();

        //var customers = new CustomerModel[] {
        //        new CustomerModel(){ CustomerId = 1, Name = "Arisha Barron" },
        //        new CustomerModel(){ CustomerId = 2, Name = "Branden Gibson" },
        //        new CustomerModel(){ CustomerId = 3, Name = "Rhonda Church" },
        //        new CustomerModel(){ CustomerId = 4, Name = "Georgina Hazel" }
        //    };

        //modelBuilder.Entity<CustomerModel>()
        //    .HasData(new CustomerModel() { CustomerId = 1, Name = "Arisha Barron" });

        //base.OnModelCreating(modelBuilder); //what does this do?
    }
    
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerModel>().HasData(
            new CustomerModel
            {
                CustomerId = 1,
                Name = "Arisha Barron",

            }
        );
    }
}

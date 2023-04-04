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
    }
    
}

using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

namespace BankAPI.Models;

public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options)
    : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<TransferHistory> TransferHistory { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) //specifies tables and their relationships
    {
        modelBuilder.Entity<Customer>()
                    .HasMany(c => c.AccountsList)
                    .WithOne(a => a.Customer);

        modelBuilder.Entity<Account>()
                    .HasMany(a => a.TransferHistory);
    }
    
}

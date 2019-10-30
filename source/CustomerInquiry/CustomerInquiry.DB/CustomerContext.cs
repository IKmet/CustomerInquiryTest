using CustomerInquiry.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.DB
{
  public class CustomerContext : DbContext
  {
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>()
          .HasIndex(e => e.Email)
          .IsUnique();
    }
  }
}

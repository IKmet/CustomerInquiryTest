using CustomerInquiry.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.DB {
  class CustomerContext : DbContext {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Customer>()
          .HasIndex(e => e.Email)
          .IsUnique();
    }
  }
}

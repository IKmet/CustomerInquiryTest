using CustomerInquiry.Infrastructure.DataAccess.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Infrastructure.DataAccess.SQL
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

using CustomerInquiry.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.DB.DataAccess {
  public class CustomerInfoProvider: ICustomerInfoProvider {
    private const int AmountRecentTransactions = 5;

    private readonly CustomerContext context;

    public CustomerInfoProvider(CustomerContext context) {
      this.context = context;
    }

    public async Task<IEnumerable<Common.DTO.Customer>> GetRecentCustomerTransactions(Common.DTO.CustomerInquiryCriteria customer) {
      var customers = context.Customers.AsQueryable();

      if (customer.Id != default) {
        customers = customers.Where(c => c.Id == customer.Id);
      }

      if (String.IsNullOrEmpty(customer.Email)) {
        customers = customers.Where(c => c.Email == customer.Email);
      }

      return await customers
        .Select(res => new Common.DTO.Customer {
          Id = res.Id,
          Name = res.Name,
          Email = res.Email,
          MobileNumber = res.MobileNumber,
          Transactions = res.Transactions.Take(AmountRecentTransactions).Cast<Common.DTO.Transaction>()
        })
        .ToListAsync();
    }
  }
}

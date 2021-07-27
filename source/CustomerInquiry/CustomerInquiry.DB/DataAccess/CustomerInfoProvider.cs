using AutoMapper;
using CustomerInquiry.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.DB.DataAccess
{
    public class CustomerInfoProvider : ICustomerInfoProvider
    {
        private const int AmountRecentTransactions = 5;

        private const int MobileNumberLength = 10;

        private readonly CustomerContext context;

        private readonly IMapper mapper;

        public CustomerInfoProvider(CustomerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Common.DTO.Customer> GetRecentCustomerTransactions(Common.DTO.CustomerInquiryCriteria customer)
        {
            var customers = context.Customers.AsQueryable();
            if (customer.Id != default)
            {
                customers = customers.Where(c => c.Id == customer.Id);
            }

            if (!String.IsNullOrEmpty(customer.Email))
            {
                customers = customers.Where(c => c.Email == customer.Email);
            }

            return await customers
              .Select(res => new Common.DTO.Customer
              {
                  Id = res.Id,
                  Name = res.Name,
                  Email = res.Email,
                  MobileNumber = res.MobileNumber.ToString($"D{MobileNumberLength}"),
                  Transactions = res.Transactions
                  .OrderByDescending(t => t.DateTime)
                  .Take(AmountRecentTransactions)
                  .Select(t => mapper.Map<Common.DTO.Transaction>(t))
              })
              .FirstOrDefaultAsync();
        }
    }
}

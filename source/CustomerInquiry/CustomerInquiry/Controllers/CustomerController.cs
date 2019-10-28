using CustomerInquiry.Common.DTO;
using CustomerInquiry.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerInquiry.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : Controller {
    private readonly ICustomerInfoProvider customerInfoProvider;

    public CustomerController(ICustomerInfoProvider customerInfoProvider) {
      this.customerInfoProvider = customerInfoProvider;
    }

    [Route("recenttransactions")]
    [HttpPost]
    public async Task<IEnumerable<Customer>> GetRecentCustomerTransactions([FromBody] CustomerBase customerRequest) {
      return await customerInfoProvider.GetRecentCustomerTransactions(customerRequest);
    }
  }
}

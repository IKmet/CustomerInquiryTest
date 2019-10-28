using CustomerInquiry.ActionFilters;
using CustomerInquiry.Common.DTO;
using CustomerInquiry.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    [ServiceFilter(typeof(CustomerInquiryFilter))]
    public async Task<IActionResult> GetRecentCustomerTransactions([FromBody] CustomerInquiryCriteria customerRequest) {
      try {
        var result = await customerInfoProvider.GetRecentCustomerTransactions(customerRequest);
        if (result != null) {
          return Ok(result);
        }
        else {
          return NotFound();
        }
      }
      catch {
        return BadRequest();
      }
    }
  }
}

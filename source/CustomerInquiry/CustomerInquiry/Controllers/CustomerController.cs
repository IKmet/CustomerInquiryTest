using CustomerInquiry.ActionFilters;
using CustomerInquiry.Common.DTO;
using CustomerInquiry.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerInquiry.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : Controller
  {
    private readonly ICustomerInfoProvider customerInfoProvider;

    public CustomerController(ICustomerInfoProvider customerInfoProvider)
    {
      this.customerInfoProvider = customerInfoProvider;
    }

    /// <summary>
    /// Gets recent customer's transactions
    /// </summary>
    /// <param name="inquiryCriteria">Customer inquiry criteria</param>   
    [Route("recenttransactions")]
    [HttpPost]
    [ServiceFilter(typeof(CustomerInquiryFilter))]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<IActionResult> GetRecentCustomerTransactions([FromBody] CustomerInquiryCriteria inquiryCriteria)
    {
      try
      {
        var result = await customerInfoProvider.GetRecentCustomerTransactions(inquiryCriteria);
        if (result != null)
        {
          return Ok(result);
        }
        else
        {
          return NotFound();
        }
      }
      catch
      {
        return BadRequest();
      }
    }
  }
}

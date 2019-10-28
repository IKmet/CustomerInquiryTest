using CustomerInquiry.Common.DTO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CustomerInquiry.ActionFilters {

  public class CustomerInquiryFilter : IActionFilter {

    private const string NullRequestMessage = "No inquiry criteria";

    public void OnActionExecuting(ActionExecutingContext context) {
      var param = context.ActionArguments.SingleOrDefault(p => p.Value is CustomerInquiryCriteria);
      var criteriaValue = param.Value as CustomerInquiryCriteria;

      //case when criteriaValue is null is handled by default
      if (criteriaValue.Id == null && criteriaValue.Email == null) {
        context.Result = new BadRequestObjectResult(NullRequestMessage);
        return;
      }

      if (!context.ModelState.IsValid) {
        //in case of multiple model state errors, all will be shown
        context.Result = new BadRequestObjectResult(context.ModelState);
      }
    }

    public void OnActionExecuted(ActionExecutedContext context) {
    }
  }
}

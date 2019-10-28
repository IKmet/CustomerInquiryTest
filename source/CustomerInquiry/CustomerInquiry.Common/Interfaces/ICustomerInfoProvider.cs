using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerInquiry.Common.Interfaces {
  public interface ICustomerInfoProvider {
    Task<IEnumerable<Common.DTO.Customer>> GetRecentCustomerTransactions(Common.DTO.CustomerBase customer);
  }
}
using CustomerInquiry.Common.DTO;
using System.Threading.Tasks;

namespace CustomerInquiry.Common.Interfaces
{
    public interface ICustomerInfoProvider
    {
        Task<Customer> GetRecentCustomerTransactions(CustomerInquiryCriteria customer);
    }
}
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using CustomerInquiry.Common.DTO;
using CustomerInquiry.Common.Interfaces;

namespace CustomerInquiry.Infrastructure.DataAccess.DynamoDb
{
    public class DynamoDbCustomerInfoProvider : ICustomerInfoProvider
    {
        private readonly IAmazonDynamoDB _amazonDynamoDb;

        public DynamoDbCustomerInfoProvider(IAmazonDynamoDB amazonDynamoDb)
        {
            this._amazonDynamoDb = amazonDynamoDb;
        }

        public Task<Customer> GetRecentCustomerTransactions(CustomerInquiryCriteria customer)
        {
            throw new System.NotImplementedException();
        }
    }
}

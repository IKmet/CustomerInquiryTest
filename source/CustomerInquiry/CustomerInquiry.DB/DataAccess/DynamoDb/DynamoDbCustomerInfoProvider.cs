using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
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

        public async Task<Customer> GetRecentCustomerTransactions(CustomerInquiryCriteria customer)
        {
            var key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { N = "1" } }
            };

            var request = new GetItemRequest("Customer", key);
            try
            {
                var response = await this._amazonDynamoDb.GetItemAsync(request);

                return ParseResult(response.Item);
            }
            catch (AmazonDynamoDBException ex)
            {
                //logger
                return null;
            }            
            catch (Exception ex)
            {
                //logger
                return null; //TODO: change returning type for nice exceptions
            }
        }

        private Customer ParseResult(Dictionary<string, AttributeValue> response)
        {
            var customer = new Customer
            {
                Id = response.TryGetValue(nameof(Customer.Id), out var idValue) ? int.Parse(idValue.N) : throw new MissingPrimaryKeyException(),
                Email = response.TryGetValue(nameof(Customer.Email), out var emailValue) ? emailValue.S : string.Empty,
                Name = response.TryGetValue(nameof(Customer.Name), out var nameValue) ? nameValue.S : string.Empty,
                MobileNumber = response.TryGetValue(nameof(Customer.MobileNumber), out var mobileValue) ? mobileValue.S : string.Empty,
            };

            var transactions = response.TryGetValue(nameof(Customer.Transactions), out var transactionValue) ? transactionValue.L : null;
            var customerTransactions = new List<Transaction>();
            if (transactions != null && transactions.Any())
            {
                foreach (var tr in transactions)
                {
                    var transaction = new Transaction
                    {
                        Id = tr.M.TryGetValue(nameof(Transaction.Id), out var trIdValue) ? int.Parse(trIdValue.N) : throw
                        new MissingPrimaryKeyException(),
                        DateTime = tr.M.TryGetValue(nameof(Transaction.DateTime), out var trDateTimeValue) ? trDateTimeValue : DateTime.Now,
                    };

                    customerTransactions.Add(transaction);
                }
            }

            customer.Transactions = customerTransactions;

            return customer;
        }
    }
}

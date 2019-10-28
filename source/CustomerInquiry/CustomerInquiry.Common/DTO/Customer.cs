using System.Collections.Generic;

namespace CustomerInquiry.Common.DTO {
  public class Customer {
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string MobileNumber { get; set; }

    public IEnumerable<Transaction> Transactions { get; set; }
  }
}

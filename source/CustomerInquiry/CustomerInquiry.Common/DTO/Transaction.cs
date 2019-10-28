using CustomerInquiry.DB.Enums;
using System;

namespace CustomerInquiry.Common.DTO {
  public class Transaction {
    public long Id { get; set; }

    public DateTime DateTime { get; set; }

    public decimal Amount { get; set; }

    public CurrencyCode Code { get; set; }

    public Status Status { get; set; }
  }
}

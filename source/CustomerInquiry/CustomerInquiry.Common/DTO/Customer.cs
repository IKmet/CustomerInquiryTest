﻿using System.Collections.Generic;

namespace CustomerInquiry.Common.DTO {
  public class Customer : CustomerBase {
    public string Name { get; set; }

    public long MobileNumber { get; set; }

    public IList<Transaction> Transactions { get; set; }
  }
}

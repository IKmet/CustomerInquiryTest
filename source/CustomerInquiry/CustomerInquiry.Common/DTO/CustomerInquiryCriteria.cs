﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerInquiry.Common.DTO
{
  public class CustomerInquiryCriteria
  {
    [Range(1, Int32.MaxValue, ErrorMessage = "Invalid Customer ID")]
    public int? Id { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; }
  }
}
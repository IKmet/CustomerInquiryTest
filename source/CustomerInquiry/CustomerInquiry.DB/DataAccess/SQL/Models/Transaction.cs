using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerInquiry.Common.Enums;

namespace CustomerInquiry.Infrastructure.DataAccess.SQL.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public CurrencyCode Currency { get; set; }

        public Status Status { get; set; }

        public int CustomerId { get; set; }
    }
}

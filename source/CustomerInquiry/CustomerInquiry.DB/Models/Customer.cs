using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerInquiry.DB.Models {
  public class Customer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; }

    [MaxLength(25)]
    public string Email { get; set; }

    public int MobileNumber { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
  }
}

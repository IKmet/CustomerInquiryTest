namespace CustomerInquiry.Common.DTO
{
    public class Transaction
    {
        public int Id { get; set; }

        public string DateTime { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }
    }
}

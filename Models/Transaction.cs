namespace Banking.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public string? description { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }
        public string account_number { get; set; }
    }
}

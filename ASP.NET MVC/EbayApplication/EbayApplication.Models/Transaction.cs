namespace EbayApplication.Models
{
    using System;

    public class Transaction
    {
        public Guid Id { get; set; }

        public decimal Funds { get; set; }

        public TransactionType Type { get; set; }

        public DateTime Date { get; set; }
    }
}

namespace EbayApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreditCard
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public decimal Funds { get; set; }

        [Required]
        public string CardNumber { get; set; }
        
        [Required]
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Transaction> Transcations { get; set; }

        public CreditCard()
        {
            this.Transcations = new HashSet<Transaction>();
        }
    }
}

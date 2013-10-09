namespace EbayApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Delivery
    {
        [Required]
        public Guid Id { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }

        public DateTime DateShipped { get; set; }

        public DeliveryState State { get; set; }

        public int Duration { get; set; }

        public Delivery()
        {
            this.Products = new HashSet<Product>();
        }
    }
}

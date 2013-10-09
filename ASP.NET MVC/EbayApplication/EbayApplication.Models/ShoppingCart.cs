namespace EbayApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public virtual ApplicationUser Owner { get; set; }
        
        public virtual ICollection<Auction> Auctions { get; set; }
                
        public ShoppingCart()
        {
            this.Auctions = new HashSet<Auction>();
        }
    }
}

namespace EbayApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Auction
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        [Required]
        public decimal CurrentPrice { get; set; }

        [Required]
        public bool HasMaxPrice { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int DeliveryDuration { get; set; }

        [Required]
        public AuctionType Type { get; set; }

        public virtual Product Product { get; set; }

        public string CurrentBuyer { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public virtual ICollection<ApplicationUser> ParticipatingUsers { get; set; }

        public Auction()
        {
            this.ParticipatingUsers = new HashSet<ApplicationUser>();
            this.ShoppingCarts = new HashSet<ShoppingCart>();
        }

    }
}

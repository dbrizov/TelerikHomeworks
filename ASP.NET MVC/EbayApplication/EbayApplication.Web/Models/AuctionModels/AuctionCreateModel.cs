namespace EbayApplication.Web.Models.AuctionModels
{
    using EbayApplication.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AuctionCreateModel
    {
        [Required(ErrorMessage="Auction should be with valid product.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage="You have to choose: normal or auction type.")]
        public AuctionType Type { get; set; }
        
        [Required(ErrorMessage="Duration is required.")]
        [Range(typeof(int), "1", "365", ErrorMessage = "Duration should be at least {1} day and at most {2} days)")]
        public int Duration { get; set; }
        
        [Required(ErrorMessage="Current price is required")]
        [Range(typeof(decimal), "0.01", "1000000", ErrorMessage="Current price should be at least {1} and at most {2}")]
        public decimal CurrentPrice { get; set; }

        [Required(ErrorMessage = "Delivery duration is required.")]
        [Range(typeof(int), "1", "365", ErrorMessage = "Delivery duration should be at least {1} day and at most {2} days)")]
        public int DeliveryDuration { get; set; }
    }
}

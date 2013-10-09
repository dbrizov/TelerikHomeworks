namespace EbayApplication.Web.Models.ShoppingCartModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCartAddModel
    {
        [Required]
        public Guid auctionId { get; set; }
        
        [Required] 
        public Guid cartId { get; set; }
    }
}

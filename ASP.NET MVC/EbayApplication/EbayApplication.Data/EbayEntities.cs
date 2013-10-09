namespace EbayApplication.Data
{
    using System.Data.Entity;
    using EbayApplication.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class EbayEntities : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Delivery> Deliveries { get; set; }

        public IDbSet<Auction> Auctions { get; set; }

        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        public IDbSet<CreditCard> CreditCards { get; set; }

        public IDbSet<Transaction> Transactions { get; set; }
    }
}

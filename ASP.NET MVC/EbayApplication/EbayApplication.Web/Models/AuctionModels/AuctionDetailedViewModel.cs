namespace EbayApplication.Web.Models.AuctionModels
{
    using EbayApplication.Models;
    using EbayApplication.Web.Models.ProductModels;
    using System;

    public class AuctionDetailedViewModel
    {
     
        public Guid Id { get; set; }

        public DateTime DateStarted { get; set; }

        public decimal CurrentPrice { get; set; }
        
        public virtual ProductViewModel Product { get; set; }

        public AuctionType Type { get; set; }

        public string CurrentBuyer { get; set; }

        public string ProductName { get; set; }

        public DateTime ExpiringDate { get { return this.DateStarted.AddMinutes(this.Duration); } }

        public bool IsFinished { get { return DateTime.Compare(DateTime.Now, this.ExpiringDate) > 0; } } 

        public int Duration { get; set; }


        public static AuctionDetailedViewModel CreateFromAuction(Auction auction)
        {
            if (auction == null)
            {
                return null;
            }

            AuctionDetailedViewModel result = new AuctionDetailedViewModel
            {
                CurrentPrice = auction.CurrentPrice,
                DateStarted = auction.DateStarted,
                Id = auction.Id,
                Product = ProductViewModel.CreateFromProduct(auction.Product),
                Type = auction.Type,
                Duration = auction.Duration,
                CurrentBuyer = auction.CurrentBuyer
            };

            return result;
        }

     
    }
}
namespace EbayApplication.Web.Models.AuctionModels
{
    using System;

    public class AuctionViewModel
    {
        public Guid Id { get; set; }

        public DateTime ExpiringDate { get { return this.DateStarted.AddMinutes(this.Duration); } }

        public string ProductName { get; set; }

        public int Duration { get; set; }

        public DateTime DateStarted { get; set; }
    }
}
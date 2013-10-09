namespace EbayApplication.Web.Models.UserModels
{
    using System;

    public class UserBetModel
    {
        public Guid AuctionId{ get; set; }

        public decimal OfferedPrice { get; set; }
    }
}
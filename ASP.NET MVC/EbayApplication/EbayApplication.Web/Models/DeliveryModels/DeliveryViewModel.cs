namespace EbayApplication.Web.Models.DeliveryModels
{
    using System;
    using EbayApplication.Models;
    
    public class DeliveryViewModel
    {
        public Guid Id { get; set; }

        public DeliveryState State { get; set; }

        public DateTime TimeToArrive { get { return this.DateShipped.AddMinutes(this.Duration); } }

        public int Duration { get; set; }

        public DateTime DateShipped { get; set; }
    }

}
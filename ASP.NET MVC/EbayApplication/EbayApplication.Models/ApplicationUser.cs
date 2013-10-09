namespace EbayApplication.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    
    public class ApplicationUser : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual CreditCard CreditCard { get; set; }

        public virtual ICollection<Auction> CurrentAuctions { get; set; }

        public ApplicationUser()
        {
            this.CurrentAuctions = new HashSet<Auction>();
        }
    }
}

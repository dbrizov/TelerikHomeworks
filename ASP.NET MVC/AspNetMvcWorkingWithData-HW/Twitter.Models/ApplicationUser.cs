using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Twitter.Models
{
    public class ApplicationUser : User
    {
        public virtual ICollection<Tweet> Tweets { get; set; }

        public ApplicationUser()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    }
}

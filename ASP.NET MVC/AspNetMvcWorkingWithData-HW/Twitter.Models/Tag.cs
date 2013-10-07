using System;
using System.Collections.Generic;
using System.Linq;

namespace Twitter.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }

        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    }
}

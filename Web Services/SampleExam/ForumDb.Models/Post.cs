using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumDb.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }
        public virtual Thread Thread { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }

        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }
    }
}

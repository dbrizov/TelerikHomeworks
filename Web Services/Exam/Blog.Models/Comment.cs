using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get ;set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<CommentResponse> CommentResponses { get; set; }

        public Comment()
        {
            this.CommentResponses = new HashSet<CommentResponse>();
        }
    }
}

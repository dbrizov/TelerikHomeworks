using System;
using System.Linq;

namespace Blog.Models
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ResponseDate { get; set; }

        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
    }
}

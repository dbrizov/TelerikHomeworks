using System;
using System.Linq;

namespace ForumDb.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}

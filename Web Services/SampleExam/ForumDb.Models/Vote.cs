using System;
using System.Linq;

namespace ForumDb.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}

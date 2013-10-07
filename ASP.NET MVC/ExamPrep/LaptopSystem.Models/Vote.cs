using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaptopSystem.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public string VotedById { get; set; }

        public virtual ApplicationUser VotedBy { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}

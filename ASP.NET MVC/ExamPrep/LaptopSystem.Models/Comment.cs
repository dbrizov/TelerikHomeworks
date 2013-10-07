using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaptopSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

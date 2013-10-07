using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvcExam.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Category name must be between {1} and {2} characters")]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}

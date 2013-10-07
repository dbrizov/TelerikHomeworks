using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Library.Models
{
    public class CreateBookViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The Title field must be between 10 and 50 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Author field must be between 2 and 50 characters")]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
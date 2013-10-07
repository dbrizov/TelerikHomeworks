using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Twitter.Application.Models
{
    public class CreateTweetViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength=10)]
        public string Text { get; set; }
    }
}
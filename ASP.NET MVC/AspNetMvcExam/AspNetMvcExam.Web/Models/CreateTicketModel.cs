using AspNetMvcExam.Models;
using AspNetMvcExam.Web.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvcExam.Web.Models
{
    public class CreateTicketModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ticket title must be between {2} and {1} characters")]
        [ShouldNotContainTheWordBug(ErrorMessage = "The word 'bug' should not be used in the title")]
        public string Title { get; set; }

        [Required]
        public TicketPriority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        [StringLength(1500, ErrorMessage = "The description must be at most {1} charachters long")]
        public string Description { get; set; }
    }
}
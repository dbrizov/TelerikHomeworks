using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvcExam.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The content of the comment must be at most {1} characters")]
        public string Content { get; set; }
    }
}

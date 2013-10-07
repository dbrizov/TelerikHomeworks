using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvcExam.Web.Models
{
    public class PostCommentModel
    {
        [Required]
        [StringLength(500, ErrorMessage = "The comment must be at most {1} characters")]
        public string Content { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}
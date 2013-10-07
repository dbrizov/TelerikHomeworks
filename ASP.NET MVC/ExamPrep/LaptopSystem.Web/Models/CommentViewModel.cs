using LaptopSystem.Models;
using LaptopSystem.Models.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace LaptopSystem.Web.Models
{
    public class CommentViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The author name must be at most {1} characters long")]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The content of the comment must be at most {1} characters long")]
        [ShouldNotContainEmail(ErrorMessage = "The content of the comment must not contain emails")]
        public string Content { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel()
                {
                    Id = comment.Id,
                    AuthorName = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }
    }
}
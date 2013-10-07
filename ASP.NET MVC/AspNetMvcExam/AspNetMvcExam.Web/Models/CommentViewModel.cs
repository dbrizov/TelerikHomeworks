using AspNetMvcExam.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetMvcExam.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return com => new CommentViewModel()
                {
                    Id = com.Id,
                    UserName = com.User.UserName,
                    Content = com.Content
                };
            }
        }
    }
}
using Blog.Models;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Blog.Services.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string CommentedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        public static CommentModel CreateFromCommentEntity(Comment commentEntity)
        {
            var commentModel = new CommentModel()
            {
                Text = commentEntity.Text,
                CommentedBy = commentEntity.User.DisplayName,
                PostDate = commentEntity.PostDate
            };

            return commentModel;
        }
    }
}
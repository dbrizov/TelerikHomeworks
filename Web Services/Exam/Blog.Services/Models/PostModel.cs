using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract]
    public class PostModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }

        public static PostModel CreateFromPostEntity(Post postEntity)
        {
            var commentEntities = postEntity.Comments;
            var commentModels = new List<CommentModel>();
            foreach (var comment in commentEntities)
            {
                commentModels.Add(CommentModel.CreateFromCommentEntity(comment));
            }

            var postModel = new PostModel()
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                PostedBy = postEntity.User.DisplayName,
                PostDate = postEntity.PostDate,
                Text = postEntity.Text,
                Tags =
                    from t in postEntity.Tags
                    select t.Name,
                Comments = commentModels
            };

            return postModel;
        }

        public static Expression<Func<Post, PostModel>> FromPostEntity()
        {
            return postEntity => new PostModel()
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                PostedBy = postEntity.User.DisplayName,
                PostDate = postEntity.PostDate,
                Text = postEntity.Text,
                Tags =
                    from t in postEntity.Tags
                    select t.Name,
                //Comments =
                //    from c in postEntity.Comments
                //    select CommentModel.CreateFromCommentEntity(c) // Това не работи, използвал съм горния метод, с него обаче правя допълнителна заявка към базата
            };
        }
    }
}
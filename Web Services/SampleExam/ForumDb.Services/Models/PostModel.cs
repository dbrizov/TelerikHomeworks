using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using ForumDb.Models;

namespace ForumDb.Services.Models
{
    [DataContract]
    public class PostModel
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "rating")]
        public string Rating { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        public static PostModel CreateFromPostEnitity(Post postEntity)
        {
            return new PostModel()
            {
                Content = postEntity.Content,
                PostDate = postEntity.PostDate,
                PostedBy = postEntity.User.Nickname,
                Rating = ((postEntity.Votes.Count == 0) ? 0 : postEntity.Votes.Select(v => v.Value).Average()) + "/5"
            };
        }
    }
}

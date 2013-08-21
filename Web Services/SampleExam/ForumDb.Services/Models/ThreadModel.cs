using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using ForumDb.Models;

namespace ForumDb.Services.Models
{
    [DataContract]
    public class ThreadModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "createdBy")]
        public string CreatedBy { get; set; }

        [DataMember(Name = "categories")]
        public IEnumerable<string> Categories { get; set; }

        [DataMember(Name = "posts")]
        public IEnumerable<PostModel> Posts { get; set; }

        public static ThreadModel CreateFromThreadEntity(Thread threadEntity)
        {
            var postModels = new List<PostModel>();
            var postEntities = threadEntity.Posts;
            foreach (var postEntity in postEntities)
            {
                postModels.Add(PostModel.CreateFromPostEnitity(postEntity));
            }

            ThreadModel threadModel = new ThreadModel()
            {
                Id = threadEntity.Id,
                Title = threadEntity.Title,
                DateCreated = threadEntity.DateCreated,
                Content = threadEntity.Content,
                CreatedBy = threadEntity.Creator.Nickname,
                Categories =
                    from cat in threadEntity.Categories
                    select cat.Name,
                Posts = postModels
            };

            return threadModel;
        }

        public static Expression<Func<Thread, ThreadModel>> FromThreadEntity()
        {
            return threadEntity => new ThreadModel()
            {
                Id = threadEntity.Id,
                Title = threadEntity.Title,
                DateCreated = threadEntity.DateCreated,
                Content = threadEntity.Content,
                CreatedBy = threadEntity.Creator.Nickname,
                Categories =
                    from cat in threadEntity.Categories
                    select cat.Name,
                Posts = threadEntity.Posts.Select(postEntity => new PostModel()
                {
                    Content = postEntity.Content,
                    PostDate = postEntity.PostDate,
                    PostedBy = postEntity.User.Nickname,
                    //Rating = postEntity.Votes.Select(vote => vote.Value).Average() + "/5"
                })
            };
        }
    }
}
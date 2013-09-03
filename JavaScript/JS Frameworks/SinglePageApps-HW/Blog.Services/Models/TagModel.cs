using Blog.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Blog.Services.Models
{
    [DataContract]
    public class TagModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int Posts { get; set; }

        public static TagModel CreateFromTagEntity(Tag tagEntity)
        {
            var tagModel = new TagModel()
            {
                Id = tagEntity.Id,
                Name = tagEntity.Name,
                Posts = tagEntity.Posts.Count
            };

            return tagModel;
        }

        public static Expression<Func<Tag, TagModel>> FromTagEntity()
        {
            return tagEntity => new TagModel()
            {
                Id = tagEntity.Id,
                Name = tagEntity.Name,
                Posts = tagEntity.Posts.Count
            };
        }
    }
}
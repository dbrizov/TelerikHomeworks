using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ForumDb.Services.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "Content")]
        public string Content { get; set; }

        [DataMember(Name = "commentDate")]
        public DateTime CommentDate { get; set; }
    }
}
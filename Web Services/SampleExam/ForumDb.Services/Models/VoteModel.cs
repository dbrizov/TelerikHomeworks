using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ForumDb.Services.Models
{
    [DataContract]
    public class VoteModel
    {
        [DataMember(Name="value")]
        public int Value { get; set; }
    }
}
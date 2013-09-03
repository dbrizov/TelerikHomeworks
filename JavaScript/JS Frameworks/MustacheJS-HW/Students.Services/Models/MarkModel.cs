using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Students.Services.Models
{
    [DataContract]
    public class MarkModel
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public int Score { get; set; }
    }
}

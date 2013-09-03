using System;
using System.Linq;
using System.Runtime.Serialization;
using Students.Data;

namespace Students.Services.Models
{
    [DataContract]
    public class MarkModel
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public int Score { get; set; }

        public static Func<Mark, MarkModel> FromMark
        {
            get
            {
                return mark => new MarkModel()
                {
                    Subject = mark.Subject,
                    Score = mark.Score
                };
            }
        }
    }
}

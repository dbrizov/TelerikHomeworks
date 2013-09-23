using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Blog.Services.Models
{
    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Twitter.Models;

namespace Twitter.Application.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Tweet> Tweets { get; set; }

        public static Expression<Func<ApplicationUser, ApplicationUserViewModel>> FromApplicationUser
        {
            get
            {
                return appUser => new ApplicationUserViewModel()
                {
                    Id = appUser.Id,
                    Tweets = appUser.Tweets.ToList(),
                    UserName = appUser.UserName
                };
            }
        }

        public static ApplicationUserViewModel CreateFromApplicationUser(ApplicationUser appUser)
        {
            return new ApplicationUserViewModel()
            {
                Id = appUser.Id,
                Tweets = appUser.Tweets.ToList(),
                UserName = appUser.UserName
            };
        }
    }
}
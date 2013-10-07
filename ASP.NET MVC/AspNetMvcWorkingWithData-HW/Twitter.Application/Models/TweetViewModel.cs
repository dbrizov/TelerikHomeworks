using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Twitter.Models;

namespace Twitter.Application.Models
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime PostDate { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return tweet => new TweetViewModel()
                {
                    Id = tweet.Id,
                    PostDate = tweet.PostDate,
                    Tags = tweet.Tags,
                    Text = tweet.Text,
                    UserName = tweet.User.UserName
                };
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticlesClient
{
    public class ArticlesResult
    {
        public IEnumerable<Article> Articles;

        public string Description { get; set; }

        public string Syndication_Url { get; set; }

        public string Title { get; set; }
    }
}

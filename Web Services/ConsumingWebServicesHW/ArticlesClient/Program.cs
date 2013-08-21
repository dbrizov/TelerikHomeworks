using System;
using System.Linq;
using System.Text;

namespace ArticlesClient
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("How many articles to display?: ");
            int count = int.Parse(Console.ReadLine());

            HttpRequester requester = new HttpRequester("http://api.feedzilla.com/v1/articles/");
            ArticlesResult result = requester.Get<ArticlesResult>("search.json?count=" + count);

            Console.WriteLine(new string('-', 79));
            Console.WriteLine("Title: {0}", result.Title);
            Console.WriteLine("Description: {0}", result.Description);
            Console.WriteLine("Syndication Url: {0}", result.Syndication_Url);
            Console.WriteLine(new string('-', 79));

            foreach (var article in result.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
                Console.WriteLine();
            }
        }
    }
}

using System;
using Wintellect.PowerCollections;

namespace TradeCompanyArticles
{
    public class TradeCompanyArticlesMain
    {
        public static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            var articles = new OrderedMultiDictionary<double, Article>(false);
            int numberOfArticles = 50;
            for (int i = 0; i < numberOfArticles; i++)
            {
                double randomPrice = randomGenerator.NextDouble() * 100;
                articles.Add(randomPrice, new Article("A", "B", "C", randomPrice));
            }

            Console.WriteLine("Select a range for price of the articles:");
            Console.Write("From: ");
            double from = double.Parse(Console.ReadLine());

            Console.Write("To: ");
            double to = double.Parse(Console.ReadLine());

            // Find the articles in the given range
            var articlesInTheGivenRange = articles.Range(from, true, to, true);

            // Print the articles in the given range
            foreach (var articleCollection in articlesInTheGivenRange)
            {
                foreach (var article in articleCollection.Value)
                {
                    Console.WriteLine(article);
                }
            }
        }
    }
}

using System;
using System.Diagnostics;
using Wintellect.PowerCollections;

namespace Products
{
    public class ProductsMain
    {
        public static void Main(string[] args)
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("---Performance test (Adding)---");
            stopwatch.Start();
            int productsCount = 500000;
            for (int i = 0; i < productsCount; i++)
            {
                bag.Add(new Product("asd", i));
            }

            stopwatch.Stop();
            Console.WriteLine("{0} products added for {1}", productsCount, stopwatch.Elapsed);

            Console.WriteLine("Choose subrange of product's price:");
            Console.Write("From: ");
            double from = double.Parse(Console.ReadLine());
            Console.Write("To :");
            double to = double.Parse(Console.ReadLine());

            var subrangeProducts = bag.Range(
                new Product("asd", from), true,
                new Product("asd", to), true);

            if (subrangeProducts.Count >= 20)
            {
                Console.WriteLine("The first 20 products in this range are:");
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("Name: {0}, Price: {1}", subrangeProducts[i].Name, subrangeProducts[i].Price);
                }
            }
            else
            {
                Console.WriteLine("The products with price in this range are:");
                for (int i = 0; i < subrangeProducts.Count; i++)
                {
                    Console.WriteLine("Name: {0}, Price: {1}", subrangeProducts[i].Name, subrangeProducts[i].Price);
                }
            }

            Console.WriteLine("---Performance test (Searching)---");
            int numberOfSearches = 10000;
            Product searchedProduct = new Product("asd", 100);

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < numberOfSearches; i++)
            {
                bag.Contains(searchedProduct);
            }

            stopwatch.Stop();
            Console.WriteLine("{0} searches for {1}", numberOfSearches, stopwatch.Elapsed);
        }
    }
}

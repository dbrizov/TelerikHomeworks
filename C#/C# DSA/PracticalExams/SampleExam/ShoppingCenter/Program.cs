using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            StringBuilder commandsBuffer = new StringBuilder();

            Shop shop = new Shop();
            CommandExecutor commandExecutor = new CommandExecutor(shop);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                string commandMessage = commandExecutor.ExecuteCommand(command);
                commandsBuffer.Append(commandMessage + "\n");
            }

            Console.WriteLine(commandsBuffer.ToString().Trim());
        }
    }

    /// <summary>
    /// Product
    /// </summary>
    public class Product : IComparable
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }

        public Product(string name, string producer, double price)
        {
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0}{1};{2};{3:f2}{4}",
                "{", this.Name, this.Producer, this.Price, "}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj is null");
            }

            Product objAsProduct = obj as Product;
            if (objAsProduct == null)
            {
                throw new InvalidCastException("The obj can't be cast to a product");
            }

            if (this.Name != objAsProduct.Name)
            {
                return false;
            }

            if (this.Producer != objAsProduct.Producer)
            {
                return false;
            }

            if (this.Price != objAsProduct.Price)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return 
                this.Name.GetHashCode() ^ 
                this.Producer.GetHashCode() + 
                this.Price.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Product objAsProduct = obj as Product;

            int compareResult = this.Name.CompareTo(objAsProduct.Name);

            if (compareResult == 0)
            {
                compareResult = this.Producer.CompareTo(objAsProduct.Producer);
            }

            if (compareResult == 0)
            {
                compareResult = this.Price.CompareTo(objAsProduct.Price);
            }

            return compareResult;
        }
    }

    /// <summary>
    /// Shop
    /// </summary>
    public class Shop
    {
        private MultiDictionary<string, Product> productsByName;
        private MultiDictionary<string, Product> productsByProducer;
        private MultiDictionary<string, Product> productsByNameAndProducer;
        private OrderedMultiDictionary<double, Product> productsByPrice;

        public Shop()
        {
            this.productsByName = new MultiDictionary<string, Product>(true);
            this.productsByProducer = new MultiDictionary<string, Product>(true);
            this.productsByNameAndProducer = new MultiDictionary<string, Product>(true);
            this.productsByPrice = new OrderedMultiDictionary<double, Product>(true);
        }

        public void AddProduct(string name, string producer, double price)
        {
            Product product = new Product(name, producer, price);
            this.productsByName.Add(name, product);
            this.productsByProducer.Add(producer, product);
            this.productsByNameAndProducer.Add(name + producer, product);
            this.productsByPrice.Add(price, product);
        }

        public int DeleteProducts(string name, string producer)
        {
            var removedProducts = this.productsByNameAndProducer[name + producer];
            int count = removedProducts.Count;

            foreach (var pr in removedProducts)
            {
                this.productsByName.Remove(pr.Name, pr);
                this.productsByProducer.Remove(pr.Producer, pr);
                this.productsByPrice.Remove(pr.Price, pr);
            }

            this.productsByNameAndProducer.Remove(name + producer);
            return count;
        }

        public int DeleteProducts(string producer)
        {
            var removedProducts = this.productsByProducer[producer];
            int count = removedProducts.Count;

            foreach (var pr in removedProducts)
            {
                this.productsByName.Remove(pr.Name, pr);
                this.productsByNameAndProducer.Remove(pr.Name + pr.Producer, pr);
                this.productsByPrice.Remove(pr.Price, pr);
            }

            this.productsByProducer.Remove(producer);
            return count;
        }

        public ICollection<Product> FindByName(string name)
        {
            return this.productsByName[name];
        }

        public ICollection<Product> FindByPrice(double from, double to)
        {
            return this.productsByPrice.Range(from, true, to, true).Values;
        }

        public ICollection<Product> FindByProducer(string producer)
        {
            return this.productsByProducer[producer];
        }
    }

    /// <summary>
    /// CommandExecutor
    /// </summary>
    public class CommandExecutor
    {
        private const string AddProduct = "AddProduct";
        private const string DeleteProducts = "DeleteProducts";
        private const string FindProductsByName = "FindProductsByName";
        private const string FindProductsByPriceRange = "FindProductsByPriceRange";
        private const string FindProductsByProducer = "FindProductsByProducer";
        private const string NProductsDeleted = "{0} products deleted";
        private const string ProductAdded = "Product added";
        private const string NoProductsFound = "No products found";

        private Shop shop;

        public CommandExecutor(Shop shop)
        {
            this.shop = shop;
        }

        public string ExecuteCommand(string command)
        {
            StringBuilder commandMessage = new StringBuilder();

            List<string> cmd = this.ParseCommand(command);

            switch (cmd[0])
            {
                case AddProduct:
                    {
                        this.shop.AddProduct(cmd[1], cmd[3], double.Parse(cmd[2]));
                        commandMessage.Append(ProductAdded);
                        break;
                    }

                case DeleteProducts:
                    {
                        int removedItemsCount = 0;
                        if (cmd.Count == 3)
                        {
                            removedItemsCount = this.shop.DeleteProducts(cmd[1], cmd[2]);
                        }
                        else
                        {
                            removedItemsCount = this.shop.DeleteProducts(cmd[1]);
                        }

                        if (removedItemsCount != 0)
                        {
                            commandMessage.AppendFormat(NProductsDeleted, removedItemsCount);
                        }
                        else
                        {
                            commandMessage.Append(NoProductsFound);
                        }

                        break;
                    }

                case FindProductsByName:
                    {
                        var products = this.shop.FindByName(cmd[1]);
                        if (products.Count != 0)
                        {
                            List<Product> sortedProducts = new List<Product>(products);
                            sortedProducts.Sort();

                            foreach (var product in sortedProducts)
                            {
                                commandMessage.Append(product + "\n");
                            }
                        }
                        else
                        {
                            commandMessage.Append(NoProductsFound);
                        }

                        break;
                    }

                case FindProductsByPriceRange:
                    {
                        double from = double.Parse(cmd[1]);
                        double to = double.Parse(cmd[2]);
                        var products = this.shop.FindByPrice(from, to);
                        if (products.Count != 0)
                        {
                            List<Product> sortedProducts = new List<Product>(products);
                            sortedProducts.Sort();

                            foreach (var product in sortedProducts)
                            {
                                commandMessage.Append(product + "\n");
                            }
                        }
                        else
                        {
                            commandMessage.Append(NoProductsFound);
                        }

                        break;
                    }

                case FindProductsByProducer:
                    {
                        var products = this.shop.FindByProducer(cmd[1]);
                        if (products.Count != 0)
                        {
                            List<Product> sortedProducts = new List<Product>(products);
                            sortedProducts.Sort();

                            foreach (var product in sortedProducts)
                            {
                                commandMessage.Append(product + "\n");
                            }
                        }
                        else
                        {
                            commandMessage.Append(NoProductsFound);
                        }

                        break;
                    }
                default:
                    commandMessage.Append("Invalid command");
                    break;
            }

            return commandMessage.ToString().Trim();
        }

        private List<string> ParseCommand(string command)
        {
            List<string> commandAsStrings = new List<string>();

            int indexOfSpace = command.IndexOf(' ');
            string commandName = command.Substring(0, indexOfSpace);
            commandAsStrings.Add(commandName);

            int startIndex = indexOfSpace + 1;
            int endIndex = command.IndexOf(';');
            while (endIndex > 0)
            {
                string parameter = command.Substring(startIndex, endIndex - startIndex);
                commandAsStrings.Add(parameter);
                startIndex = endIndex + 1;
                endIndex = command.IndexOf(';', endIndex + 1);
            }

            int indexOfLasSemicolon = command.LastIndexOf(';');
            if (indexOfLasSemicolon > 0)
            {
                string lastParameter = command.Substring(indexOfLasSemicolon + 1);
                commandAsStrings.Add(lastParameter);
            }
            else
            {
                indexOfSpace = command.IndexOf(' ');
                string lastParam = command.Substring(indexOfSpace + 1);
                commandAsStrings.Add(lastParam);
            }

            return commandAsStrings;
        }
    }
}

using System;

namespace Products
{
    public class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Can't compare null obj");
            }

            Product objAsProduct = obj as Product;
            if (objAsProduct == null)
            {
                throw new ArgumentException("obj", "The object cannot be cast to a product");
            }

            return this.Price.CompareTo(objAsProduct.Price);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Product objAsProduct = obj as Product;
            if (objAsProduct == null)
            {
                return false;
            }

            return (this.Name == objAsProduct.Name && this.Price == objAsProduct.Price);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Price.GetHashCode();
        }
    }
}

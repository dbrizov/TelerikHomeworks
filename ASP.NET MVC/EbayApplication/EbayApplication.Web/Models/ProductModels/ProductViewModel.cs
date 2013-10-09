using EbayApplication.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EbayApplication.Web.Models.ProductModels
{
    public class ProductViewModel
    {
        public static Expression<Func<Product, ProductViewModel>> FromProduct
        {
            get
            {
                return product => new ProductViewModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Category = product.Category.Name,
                    Price = product.Price,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Condition = product.Condition,
                    DateAdded = product.DateAdded,
                    StartingPrice = product.StartingPrice,
                    Owner = product.Owner.UserName
                };
            }
        }

        public static ProductViewModel CreateFromProduct(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Title = product.Title,
                Category = product.Category.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Condition = product.Condition,
                StartingPrice =product.StartingPrice,
                DateAdded = product.DateAdded,
                Owner = product.Owner.UserName
            };
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int DeliveryTime { get; set; }

        public Condition Condition { get; set; }

        public DateTime DateAdded { get; set; }

        public decimal StartingPrice { get; set; }

        public string Owner { get; set; }
    }
}
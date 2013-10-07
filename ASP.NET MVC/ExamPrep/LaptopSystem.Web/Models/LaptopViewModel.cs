using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LaptopSystem.Web.Models
{
    public class LaptopViewModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public static Expression<Func<Laptop, LaptopViewModel>> FromLaptop
        {
            get
            {
                return laptop => new LaptopViewModel()
                {
                    Id = laptop.Id,
                    Manufacturer = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    Price = laptop.Price,
                    ImageUrl = laptop.ImageUrl
                };
            }
        }
    }
}
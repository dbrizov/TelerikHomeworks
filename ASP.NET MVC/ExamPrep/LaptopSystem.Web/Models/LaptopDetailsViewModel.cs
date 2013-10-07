using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LaptopSystem.Web.Models
{
    public class LaptopDetailsViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ManufacturerName { get; set; }

        public double MonitorSize { get; set; }

        public double HardDiskSize { get; set; }

        public double RamSize { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public int Votes { get; set; }

        public bool UserHasVoted { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Laptop, LaptopDetailsViewModel>> FromLaptop
        {
            get
            {
                return laptop => new LaptopDetailsViewModel()
                {
                    AdditionalParts = laptop.AdditionalParts,
                    Comments = laptop.Comments.Select(CommentViewModel.FromComment.Compile()),
                    Description = laptop.Description,
                    HardDiskSize = laptop.HardDiskSize,
                    Id = laptop.Id,
                    ImageUrl = laptop.ImageUrl,
                    ManufacturerName = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    MonitorSize = laptop.MonitorSize,
                    Price = laptop.Price,
                    RamSize = laptop.RamSize,
                    Votes = laptop.Votes.Count(),
                    Weight = laptop.Weight
                };
            }
        }
    }
}
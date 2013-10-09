using EbayApplication.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace EbayApplication.Web.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of category is required.")]
        [StringLength(255,
            MinimumLength = 5,
            ErrorMessage = "Name should be between {2} and {1} symbols long.")]
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

        public static CategoryViewModel CreateFromCategory(Category category)
        {
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
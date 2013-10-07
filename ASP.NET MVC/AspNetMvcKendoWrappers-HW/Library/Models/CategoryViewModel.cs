using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Models
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength=5, ErrorMessage="The category name must be between {2} and {1} characters")]
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
    }
}
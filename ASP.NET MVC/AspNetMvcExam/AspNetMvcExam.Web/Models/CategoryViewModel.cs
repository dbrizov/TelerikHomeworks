using AspNetMvcExam.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetMvcExam.Web.Models
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Category name must be between {2} and {1} characters")]
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
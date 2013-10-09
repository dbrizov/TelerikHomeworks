namespace EbayApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Required(ErrorMessage = "Id should be valid Guid value.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title of product is required.")]
        [StringLength(255,
            MinimumLength = 3,
            ErrorMessage = "Title should be between {1} and {2} symbols long.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description of product is required.")]
        [MinLength(30, ErrorMessage = "Description should be at least {1} symbols long.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price of product is required.")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Price should be non negative decimal value.")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, 
            ErrorMessage = "Price should be non negative decimal value.")]
        public decimal StartingPrice { get; set; }

        [Required(ErrorMessage = "Date of adding is required.")]
        public DateTime DateAdded { get; set; }

        public Condition Condition { get; set; }

        public ProductState State { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}

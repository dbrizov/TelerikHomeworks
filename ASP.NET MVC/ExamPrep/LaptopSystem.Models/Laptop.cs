using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaptopSystem.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [Range(5, 20, ErrorMessage = "The MonitorSize must be between {2} and {1} inches")]
        public double MonitorSize { get; set; }

        [Required]
        [Range(100, 2000, ErrorMessage = "The hard disk size must be between {2} and {1} Gigabytes")]
        public double HardDiskSize { get; set; }

        [Required]
        [Range(1, 32, ErrorMessage = "The RAM size must be between {2} and {1} Gugabytes")]
        public double RamSize { get; set; }

        [Required]
        [StringLength(2048, MinimumLength = 5, ErrorMessage = "The image url must be betwwen {2} and {1} characters")]
        public string ImageUrl { get; set; }

        [Required]
        [Range(600, 3000, ErrorMessage = "The price must be between {2} and {1} dollars")]
        public decimal Price { get; set; }

        [Range(0, 10, ErrorMessage = "The weight of the laptop must be between {2} and {1} kilos")]
        public double? Weight { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "The Additional Parts field must be bewteen {2} and {1} characters")]
        public string AdditionalParts { get; set; }

        [StringLength(1000, MinimumLength = 5, ErrorMessage = "The Description field must be bewteen {2} and {1} characters")]
        public string Description { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Laptop()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaptopSystem.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }

        public Manufacturer()
        {
            this.Laptops = new HashSet<Laptop>();
        }
    }
}

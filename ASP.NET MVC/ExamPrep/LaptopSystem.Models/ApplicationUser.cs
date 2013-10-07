using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaptopSystem.Models
{
    public class ApplicationUser : User
    {
        [Required]
        public string Email { get; set; }
    }
}

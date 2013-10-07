using LaptopSystem.Models.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaptopSystem.Web.Models
{
    public class PostCommentModel
    {
        [Required]
        [ShouldNotContainEmail]
        public string Comment { get; set; }

        [Required]
        public int LaptopId { get; set; }
    }
}
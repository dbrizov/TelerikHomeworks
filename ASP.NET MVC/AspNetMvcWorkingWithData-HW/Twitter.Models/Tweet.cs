using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength=10)]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }
    }
}

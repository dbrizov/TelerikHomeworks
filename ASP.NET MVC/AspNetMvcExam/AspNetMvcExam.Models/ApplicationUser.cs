using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace AspNetMvcExam.Models
{
    public class ApplicationUser : User
    {
        public int Points { get; set; }
    }
}

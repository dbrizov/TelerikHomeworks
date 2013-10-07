using System;
using System.Linq;

namespace MoviesApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string LeadingMaleRole { get; set; }
        public string LeadingFemaleRole { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }
    }
}
using MoviesApplication.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoviesApplication.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string LeadingMaleRole { get; set; }
        public string LeadingFemaleRole { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }

        public static Expression<Func<Movie, MovieViewModel>> FromMovieEntity
        {
            get
            {
                return movie => new MovieViewModel()
                {
                    Id = movie.Id,
                    Director = movie.Director,
                    LeadingFemaleRole = movie.LeadingFemaleRole,
                    LeadingMaleRole = movie.LeadingMaleRole,
                    Studio = movie.Studio,
                    StudioAddress = movie.StudioAddress,
                    Title = movie.Title,
                    Year = movie.Year
                };
            }
        }

        public static MovieViewModel CreateFromMovieEntity(Movie entity)
        {
            return new MovieViewModel()
            {
                Id = entity.Id,
                Director = entity.Director,
                LeadingFemaleRole = entity.LeadingFemaleRole,
                LeadingMaleRole = entity.LeadingMaleRole,
                Studio = entity.Studio,
                StudioAddress = entity.StudioAddress,
                Title = entity.Title,
                Year = entity.Year
            };
        }
    }
}
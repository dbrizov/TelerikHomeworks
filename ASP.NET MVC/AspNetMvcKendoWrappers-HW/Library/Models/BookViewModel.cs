using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Models
{
    public class BookViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The book title must be at most {1} characters long")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The book author must be at most {1} characters long")]
        public string Author { get; set; }

        [StringLength(100, ErrorMessage = "The book title must be at most {1} characters long")]
        public string Isbn { get; set; }

        [StringLength(255, ErrorMessage = "The book title must be at most {1} characters long")]
        public string WebSite { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel()
                {
                    Author = book.Author,
                    CategoryName = book.Category.Name,
                    CategoryId = book.CategoryId,
                    Description = book.Description,
                    Id = book.Id,
                    Isbn = book.Isbn,
                    Title = book.Title,
                    WebSite = book.WebSite
                };
            }
        }

        public static BookViewModel CreateFromBook(Book book)
        {
            return new BookViewModel()
            {
                Author = book.Author,
                CategoryName = book.Category.Name,
                CategoryId = book.CategoryId,
                Description = book.Description,
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                WebSite = book.WebSite
            };
        }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Content = book.Content,
                    CategoryId = book.Category.Id,
                    Category = book.Category.Name
                };
            }
        }

        public static BookViewModel CreateFromBook(Book book)
        {
            return new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Content = book.Content,
                CategoryId = book.Category.Id,
                Category = book.Category.Name
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public class BooksByCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }

        public static BooksByCategoryViewModel CreateFromCategory(Category category)
        {
            var books = category.Books.Select(BookViewModel.FromBook.Compile());

            var result = new BooksByCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Books = books
            };

            return result;
        }
    }
}
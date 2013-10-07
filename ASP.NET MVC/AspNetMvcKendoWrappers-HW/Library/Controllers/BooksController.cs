using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IUnitOfWorkData db;

        public BooksController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            ViewBag.Categories = this.db.Categories.All()
                .Select(CategoryViewModel.FromCategory)
                .OrderBy(c => c.Name)
                .ToList();

            return View();
        }

        public ActionResult Details(int? bookId)
        {
            if (bookId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = this.db.Books.GetById(bookId);
            if (book == null)
            {
                return new HttpNotFoundResult("The book was not found");
            }

            var model = BookViewModel.CreateFromBook(book);

            return View(model);
        }

        public JsonResult All([DataSourceRequest] DataSourceRequest request)
        {
            var books = this.db.Books.All().Select(BookViewModel.FromBook).ToList();

            return Json(books.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, BookViewModel bookModel)
        {
            if (bookModel != null && ModelState.IsValid)
            {
                var newBook = new Book()
                {
                    Author = bookModel.Author,
                    Category = this.db.Categories.GetById(bookModel.CategoryId),
                    Description = bookModel.Description,
                    Isbn = bookModel.Isbn,
                    Title = bookModel.Title,
                    WebSite = bookModel.WebSite
                };

                this.db.Books.Add(newBook);
                this.db.SaveChanges();
            }

            return Json(new[] { bookModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, BookViewModel bookModel)
        {
            if (bookModel != null && ModelState.IsValid)
            {
                var existingBook = this.db.Books.All().FirstOrDefault(b => b.Id == bookModel.Id);
                existingBook.Author = bookModel.Author;
                existingBook.Category = this.db.Categories.GetById(bookModel.CategoryId);
                existingBook.Description = bookModel.Description;
                existingBook.Isbn = bookModel.Isbn;
                existingBook.Title = bookModel.Title;
                existingBook.WebSite = bookModel.WebSite;

                this.db.Books.Update(existingBook);
                this.db.SaveChanges();
            }

            return Json(new[] { bookModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, BookViewModel bookModel)
        {
            var existingBook = this.db.Books.All().FirstOrDefault(b => b.Id == bookModel.Id);

            this.db.Books.Delete(existingBook);
            this.db.SaveChanges();

            return Json(new[] { bookModel }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBooks(string text)
        {
            var bookModels = this.db.Books.All()
                .Where(b => b.Title.ToLower().Contains(text.ToLower()) ||
                            b.Author.ToLower().Contains(text.ToLower()))
                .Select(BookViewModel.FromBook);

            return Json(bookModels, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Search(string query)
        {
            var bookModels = this.db.Books.All()
                .Where(p => p.Title.ToLower().Contains(query.ToLower()) ||
                            p.Author.ToLower().Contains(query.ToLower()))
                .Select(BookViewModel.FromBook);


            return View(bookModels.ToList());
        }
    }
}
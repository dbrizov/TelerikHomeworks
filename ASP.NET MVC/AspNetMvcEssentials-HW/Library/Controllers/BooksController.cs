using System.Data.Entity;
using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWorkData db;

        public BooksController()
        {
            this.db = new UnitOfWorkData();
        }

        [HttpGet]
        public ActionResult All(int? page)
        {
            ViewBag.Categories = this.db.Categories.All().ToList()
                .Select(cat => new SelectListItem()
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString()
                });

            var books = this.db.Books.All()
                .Include("Category")
                .Select(BookViewModel.FromBook)
                .OrderBy(b => b.Title);

            int pageSize = 10;
            int pageNumber = (page == null ? 1 : (int)page);

            return View(books.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = this.db.Books.GetById(id);
            if (book == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "There is no book with id=" + id);
            }

            var bookModel = BookViewModel.CreateFromBook(book);

            return View(bookModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = this.db.Categories.All().ToList()
                .Select(cat => new SelectListItem()
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString()
                });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CreateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book()
                {
                    Author = model.Author,
                    Content = model.Content,
                    Title = model.Title,
                    Category = this.db.Categories.GetById(model.CategoryId)
                };

                this.db.Books.Add(book);
                this.db.SaveChanges();

                return RedirectToAction("All");
            }

            ViewBag.Categories = this.db.Categories.All().ToList()
               .Select(cat => new SelectListItem()
               {
                   Text = cat.Name,
                   Value = cat.Id.ToString()
               });

            return View();
        }
    }
}
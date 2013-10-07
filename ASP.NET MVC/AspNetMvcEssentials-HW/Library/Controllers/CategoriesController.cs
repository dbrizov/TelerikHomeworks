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
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWorkData db;

        public CategoriesController()
        {
            this.db = new UnitOfWorkData();
        }

        [HttpGet]
        public ActionResult All(int? page)
        {
            var categories = this.db.Categories.All()
                .Select(CategoryViewModel.FromCategory)
                .OrderBy(cat => cat.Name);

            int pageSize = 10;
            int pageNumber = (page == null ? 1 : (int)page);

            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Books(int? categoryId, int? page)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var books = this.db.Books.All()
                .Include("Category")
                .Where(b => b.Category.Id == categoryId)
                .Select(BookViewModel.FromBook)
                .OrderBy(b => b.Title);

            int pageSize = 10;
            int pageNumber = (page == null ? 1 : (int)page);

            return PartialView("Partials/_Books", books.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CategoryViewModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = model.Name
                };

                this.db.Categories.Add(category);
                this.db.SaveChanges();

                return RedirectToAction("All");
            }

            return View();
        }
    }
}
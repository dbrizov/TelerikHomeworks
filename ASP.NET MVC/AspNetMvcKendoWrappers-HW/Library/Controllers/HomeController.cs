using System.Data.Entity;
using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Data;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkData db;

        public HomeController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            var categories = this.db.Categories.All().Include("Books").ToList();

            var model = new List<BooksByCategoryViewModel>();
            foreach (var category in categories)
            {
                model.Add(BooksByCategoryViewModel.CreateFromCategory(category));
            }

            return View(model);
        }
    }
}
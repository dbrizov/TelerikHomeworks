using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWorkData db;

        public CategoriesController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult All([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.db.Categories.All()
                .Select(CategoryViewModel.FromCategory).ToList();

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            if (categoryModel != null && ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    Name = categoryModel.Name
                };

                this.db.Categories.Add(newCategory);
                this.db.SaveChanges();
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Update([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            if (categoryModel != null && ModelState.IsValid)
            {
                var existingCategory = this.db.Categories.All().FirstOrDefault(c => c.Id == categoryModel.Id);
                existingCategory.Name = categoryModel.Name;

                this.db.Categories.Update(existingCategory);
                this.db.SaveChanges();
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            var existingCategory = this.db.Categories.All().FirstOrDefault(c => c.Id == categoryModel.Id);

            this.db.Categories.Delete(existingCategory);
            this.db.SaveChanges();

            return Json(new[] { categoryModel }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Linq;
using System.Web.Mvc;
using EbayApplication.Repositories;
using EbayApplication.Web.Areas.Admin.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using EbayApplication.Models;

namespace EbayApplication.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly IUnitOfWorkData db;

        public AdminCategoriesController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            if (string.IsNullOrWhiteSpace(categoryModel.Name))
            {
                ModelState.AddModelError("Name", "The 'Category Name' field is required");
            }
            else if (categoryModel.Name.Length < 5 || categoryModel.Name.Length > 255)
            {
                ModelState.AddModelError("Name", "The 'Category Name' field must between 5 and 255 characters");
            }
            else
            {
                var newCategory = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = categoryModel.Name
                };

                this.db.Categories.Add(newCategory);
                this.db.SaveChanges();
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = this.db.Categories.All()
                .Select(CategoryViewModel.FromCategory);

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = this.db.Categories.GetById(categoryModel.Id);
                if (existingCategory != null)
                {
                    existingCategory.Name = categoryModel.Name;

                    this.db.Categories.Update(existingCategory);
                    this.db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Category", "This category does not exist anymore and cant' be updated");
                }
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
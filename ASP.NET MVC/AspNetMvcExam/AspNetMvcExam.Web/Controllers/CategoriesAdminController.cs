using AspNetMvcExam.Models;
using AspNetMvcExam.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcExam.Web.Controllers
{
    public class CategoriesAdminController : AdminController
    {
        public CategoriesAdminController()
            : base()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    Name = categoryModel.Name
                };

                this.data.Categories.Add(newCategory);
                this.data.SaveChanges();
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = this.data.Categories.All()
                .Select(CategoryViewModel.FromCategory);

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = this.data.Categories.GetById(categoryModel.Id);
                if (existingCategory != null)
                {
                    existingCategory.Name = categoryModel.Name;

                    this.data.Categories.Update(existingCategory);
                    this.data.SaveChanges();
                }
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryModel)
        {
            var existingCategory = this.data.Categories.GetById(categoryModel.Id);
            if (existingCategory != null)
            {
                var tickets = existingCategory.Tickets.ToList();
                foreach (var ticket in tickets)
                {
                    var comments = ticket.Comments.ToList();
                    foreach (var comment in comments)
                    {
                        this.data.Comments.Delete(comment);
                    }

                    this.data.Tickets.Delete(ticket);
                }

                this.data.Categories.Delete(existingCategory);
                this.data.SaveChanges();
            }

            return Json(new[] { categoryModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
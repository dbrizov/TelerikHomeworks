using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EbayApplication.Repositories;
using EbayApplication.Web.Areas.Admin.Models;
using EbayApplication.Web.Models.ProductModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using EbayApplication.Models;

namespace EbayApplication.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminProductsController : Controller
    {
        private readonly IUnitOfWorkData db;

        public AdminProductsController(IUnitOfWorkData unitOfWor)
        {
            this.db = unitOfWor;
        }
        
        public AdminProductsController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult UpdateProduct(ProductViewModel productModel)
        {
            if (string.IsNullOrWhiteSpace(productModel.Title))
            {
                ModelState.AddModelError("Title", "The title must be between 3 and 255 characters");
            }

            var existingProduct = this.db.Products.All().FirstOrDefault(p => p.Id == productModel.Id);
            if (existingProduct != null)
            {
                existingProduct.Title = productModel.Title;
                existingProduct.Description = productModel.Description;
                existingProduct.Category = this.db.Categories.All().FirstOrDefault(c => c.Name == productModel.Category);
                existingProduct.Condition = productModel.Condition;

                this.db.Products.Update(existingProduct);
                this.db.SaveChanges();
            }

            return RedirectToAction("Index", "AdminProducts");
        }

        public JsonResult ReadProducts([DataSourceRequest] DataSourceRequest request)
        {
            var products = this.db.Products.All()
                .Select(ProductViewModel.FromProduct);

            return Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadCategories()
        {
            var categories = this.db.Categories.All()
                .Select(CategoryViewModel.FromCategory);

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadProductConditions()
        {
            string[] conditionNames = Enum.GetNames(typeof(Condition));
            var conditions = new List<object>();

            for (int i = 0; i < conditionNames.Length; i++)
            {
                conditions.Add(new ProductConditionViewModel(i, conditionNames[i]));
            }

            return Json(conditions, JsonRequestBehavior.AllowGet);
        }
	}
}
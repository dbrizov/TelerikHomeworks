using EbayApplication.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;
using EbayApplication.Web.Models.ProductModels;

namespace EbayApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkData db;

        public HomeController(IUnitOfWorkData db)
        {
            this.db = db;
        }
        public HomeController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            int productsCount = 24;
            
            var products = this.db.Auctions.All()
                .Select(a => new ProductViewModel()
                {
                    Condition = a.Product.Condition,
                    Category = a.Product.Category.Name,
                    DateAdded = a.Product.DateAdded,
                    DeliveryTime = a.DeliveryDuration,
                    Description = a.Product.Description,
                    Id = a.Product.Id,
                    ImageUrl = a.Product.ImageUrl,
                    Price = a.CurrentPrice,
                    Title = a.Product.Title
                })
                .OrderByDescending(p => p.DateAdded)
                .Take(productsCount)
                .ToList();

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
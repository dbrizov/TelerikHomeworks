namespace EbayApplication.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using EbayApplication.Models;
    using EbayApplication.Repositories;
    using EbayApplication.Web.Models.ProductModels;
    using PagedList;
    using System.IO;
    using EbayApplication.Web.Models.AuctionModels;
    using Microsoft.AspNet.Identity;

    public class ProductsController : Controller
    {

        private readonly IUnitOfWorkData db;

        public ProductsController(IUnitOfWorkData db)
        {
            this.db = db;
        }

        public ProductsController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            var products = db.Products.All();

            var data = products
               .Select(ProductViewModel.FromProduct);

            return View(data);
        }

        [Authorize]
        public ActionResult ByUser()
        {
            string loggedUserId = User.Identity.GetUserId();

            IQueryable<ProductViewModel> products =
                this.db.Products
                    .All()
                    .Where(product => product.OwnerId == loggedUserId)
                    .Select(ProductViewModel.FromProduct);

            return View(products);
        }


        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            ProductViewModel currentProduct = ProductViewModel.CreateFromProduct(product);

            Auction currentAuctionEntity = this.db.Auctions.All().FirstOrDefault(auction => auction.Product.Id == currentProduct.Id);

            AuctionDetailedViewModel currentAuction = AuctionDetailedViewModel.CreateFromAuction(currentAuctionEntity);

            ProductDetailedViewModel model = new ProductDetailedViewModel(currentProduct, currentAuction);

            model.SimilarProducts =
                from productEntity in this.db.Products.All()
                    .Where(p => p.CategoryId == product.CategoryId)
                    .OrderBy(p => Guid.NewGuid())
                    .Take(5)
                select new ProductFlatViewModel()
                {
                    Id = productEntity.Id,
                    ImageUrl = productEntity.ImageUrl
                };

            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {   
            ViewBag.Categories = db.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View();
        }

      
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false), Authorize]
        public ActionResult Create(AddProductViewModel product)
        {
            if (product.StartingPrice >= product.Price)
            {
                ModelState.AddModelError("StartingPrice", new ArgumentOutOfRangeException("Starting price should be less than product price."));
            }

            if (ModelState.IsValid)
            {
                var cat = db.Categories.GetById(product.Category.Id);

                string ownerId = User.Identity.GetUserId();

                ApplicationUser owner = this.db.Users.All().FirstOrDefault(user => user.Id == ownerId);

                if (product.ImageUrl == null)
                {
                    product.ImageUrl = "default-product-image.jpg";
                }
                var newProduct = new Product
                {
                    Id = Guid.NewGuid(),
                    ImageUrl = product.ImageUrl,
                    Category = cat,
                    DateAdded = DateTime.Now,
                    CategoryId = product.Category.Id, // (yoan) should it be : cat.id
                    Condition = product.Condition,
                    Description = product.Description,
                    Price = Convert.ToDecimal(product.Price),
                    StartingPrice = Convert.ToDecimal(product.StartingPrice),
                    Title = product.Title,
                    State = ProductState.ForSelling,
                    Owner = owner,
                    OwnerId = ownerId
                };

                db.Products.Add(newProduct);
                db.SaveChanges();

                var newAuction = new Auction
                {
                    Id = Guid.NewGuid(),
                    DateStarted = DateTime.Now,
                    Duration = product.AuctionTime,
                    Product = newProduct,
                    Type = product.AuctionType,
                    DeliveryDuration = product.DeliveryTime,
                    
                };

                if (product.AuctionType == AuctionType.Normal)
                {
                    newAuction.CurrentPrice = product.Price;
                }
                else
                {
                    newAuction.CurrentPrice = product.StartingPrice;
                }

                this.db.Auctions.Add(newAuction);
                this.db.SaveChanges();

                return RedirectToAction("Details", "Products", new { id = newProduct.Id });
            }

            ViewBag.Categories = db.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View(product);
        }

        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product products = this.db.Products.GetById(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            var categories = db.Categories.All().ToList();
            ViewBag.Categories = categories
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(products);
        }

    
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {               
                product.CategoryId = product.Category.Id;

                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = product.Id;
            return View(product);
        }

        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product products = this.db.Products.GetById(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            return View(products);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken, Authorize]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = db.Products.GetById(id);
            db.Products.Delete(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetPage(int page, int count)
        {
            var products = this.db.Auctions.All().Select(a => a.Product)
                .OrderByDescending(p => p.DateAdded)
                .Skip(page * count).Take(count)
                .Select(ProductViewModel.FromProduct);

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult All(int? page)
        {
            var products = this.db.Auctions.All().Select(a => a.Product)
                .OrderByDescending(p => p.DateAdded)
                .Select(ProductViewModel.FromProduct);

            int count = 10;
            page = (page == null ? 1 : (int)page);

            return View(products.ToPagedList((int)page, count));
        }

        [HttpGet]
        public JsonResult GetProducts(string text)
        {
            var productModels = this.db.Products.All()
                .Where(p => p.Title.ToLower().StartsWith(text.ToLower()))
                .Select(ProductViewModel.FromProduct);

            return Json(productModels, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Search(string product, int? page)
        {
            var products = this.db.Auctions.All().Select(a => a.Product)
                   .Where(p => p.Title.Contains(product))
                   .OrderByDescending(p => p.DateAdded)
                   .Select(ProductViewModel.FromProduct);

            int count = 10;
            page = (page == null ? 1 : (int)page);

            return View(products.ToPagedList((int)page, count));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult UploadedFiles(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var file in upload)
                {
                    if (file.ContentType == "image/jpeg" ||
                       file.ContentType == "image/gif" ||
                       file.ContentType == "image/png")
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var physicalPath = Path.Combine(Server.MapPath("~/img/products"), fileName);

                        file.SaveAs(physicalPath);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
            }
            return Content("");
        }
    }
}

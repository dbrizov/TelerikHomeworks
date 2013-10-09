namespace EbayApplication.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using EbayApplication.Models;
    using EbayApplication.Repositories;
    using EbayApplication.Web.Models.AuctionModels;

    [Authorize]
    public class ShoppingCartController : Controller
    {
        private IUnitOfWorkData db;

        public ShoppingCartController(IUnitOfWorkData db)
        {
            this.db = db;
        }

        public ShoppingCartController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult ByUser()
        {
            string loggedUserId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == loggedUserId);

            if (currentUser == null)
            {
                  return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User not found.");
            }

            IEnumerable<AuctionViewModel> model =
                from auctionEntity in currentUser.ShoppingCart.Auctions
                select new AuctionViewModel()
                {
                    DateStarted =  auctionEntity.DateStarted,
                    Duration = auctionEntity.Duration,
                    ProductName = auctionEntity.Product.Title,
                    Id = auctionEntity.Id
                };


            return View(model);
        }

        public ActionResult BuyProducts()
        {
            var user = this.db.Users.GetById(User.Identity.GetUserId());
            
            var shoppingCartId = user.ShoppingCart.Id;

            if (shoppingCartId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is required");
            }

            ShoppingCart currentCart = this.db.ShoppingCarts.All().FirstOrDefault(cart => cart.Id == shoppingCartId);

            if (currentCart == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Shopping cart, not found.");
            }

            if (currentCart.Auctions.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cart is empty.");
            }

            int deliveryDurationTime = 0;

            Delivery createdDelivery = new Delivery
            {
                Id = Guid.NewGuid(),
                DateShipped = DateTime.Now,
                Receiver = currentCart.Owner,
                State = DeliveryState.Shipping
            };

            int count = currentCart.Auctions.Count;

            foreach (Auction currentAuction in currentCart.Auctions.ToList())
            {
                createdDelivery.Products.Add(currentAuction.Product);

                deliveryDurationTime += currentAuction.DeliveryDuration;

                this.db.Auctions.Delete(currentAuction);

            }

            int time = deliveryDurationTime / count;

            createdDelivery.Duration = time;

            currentCart.Auctions.Clear();
            
            this.db.ShoppingCarts.Update(currentCart);

            this.db.Deliveries.Add(createdDelivery);
            
            this.db.SaveChanges();

            return Content("Products are shipped");
        }

        public ActionResult AddToShoppingCart(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is required");
            }

            Auction currentAuction = this.db.Auctions.All().FirstOrDefault(auction => auction.Id == id);

            string loggedUserId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == loggedUserId);

            ShoppingCart currentCart = currentUser.ShoppingCart;

            currentAuction.ShoppingCarts.Add(currentCart);

            currentCart.Auctions.Add(currentAuction);

            this.db.Auctions.Update(currentAuction);

            this.db.ShoppingCarts.Update(currentCart);

            this.db.SaveChanges();

            return Content("Product successfully added to shopping cart.");
        }

        public ActionResult RemoveFromShoppingCart(Guid? id)
        {
            string loggedUserId = User.Identity.GetUserId();

            if(loggedUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You should be logged.");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product id is required.");
            }

            ApplicationUser currentUser = this.db.Users.GetById(loggedUserId);

            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User not found.");
            }

            ShoppingCart currentCart = currentUser.ShoppingCart;

            Auction currentAuction = this.db.Auctions.GetById(id);

            if (currentAuction == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Auction not found.");
            }

            if (currentCart.Auctions.Contains(currentAuction) == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Auction is not in this cart.");
            }

            currentCart.Auctions.Remove(currentAuction);

            currentAuction.ShoppingCarts.Remove(currentCart);

            this.db.Auctions.Update(currentAuction);

            this.db.ShoppingCarts.Update(currentCart);

            this.db.SaveChanges();

            return this.Content("Auction removed successfully.");
        }
	}
}
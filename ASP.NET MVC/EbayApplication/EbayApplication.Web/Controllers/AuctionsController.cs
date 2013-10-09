namespace EbayApplication.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using EbayApplication.Models;
    using EbayApplication.Repositories;
    using EbayApplication.Web.Models.UserModels;
    using System.Globalization;
    using EbayApplication.Web.Models.AuctionModels;
    using EbayApplication.Web.Models.ProductModels;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class AuctionsController : Controller
    {
        private IUnitOfWorkData db;

        public AuctionsController(IUnitOfWorkData db)
        {
            this.db = db;
        }

        public AuctionsController()
        {
            this.db = new UnitOfWorkData();
        }

        [HttpGet]
        public ActionResult Create()
        {
            string loggedUserId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == loggedUserId);

            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User not found");
            }

            var ownProducts = this.db.Products
                                            .All()
                                            .Where(product => product.Owner.Id == currentUser.Id)
                                            .ToList()
                                            .Select(productEntity => new SelectListItem () 
                                            {
                                                Text = productEntity.Title,
                                                Value = productEntity.Id.ToString()
                                            });

            ViewBag.OwnProducts = ownProducts;

            return View();
        }

        public ActionResult ByUser()
        {
            string userId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == userId);

            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User doesn't exist");
            }

            IEnumerable<AuctionDetailedViewModel> auctions =
                    from auctionEntity in currentUser.CurrentAuctions
                    select new AuctionDetailedViewModel
                    {
                        Id = auctionEntity.Id,
                        ProductName = auctionEntity.Product.Title,
                        DateStarted = auctionEntity.DateStarted,
                        Product = ProductViewModel.CreateFromProduct(auctionEntity.Product),
                        CurrentBuyer = auctionEntity.CurrentBuyer,
                        Duration = auctionEntity.Duration
                    };
                    

            return View(auctions);
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        [Authorize]
        public ActionResult Create(AuctionCreateModel model)
        {
            string loggedUserId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.GetById(loggedUserId);

            if (ModelState.IsValid)
            {

                Product currentProduct = this.db.Products.All().FirstOrDefault(product => product.Id == model.ProductId);

                Auction newAuction = this.db.Auctions.All().FirstOrDefault(auction => auction.Product.Id == model.ProductId);

                if (newAuction != null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "There is already an auction for this product");
                }

                newAuction = new Auction
                {
                    Id = Guid.NewGuid(),
                    DateStarted = DateTime.Now,
                    Duration = model.Duration,
                    Product = currentProduct,
                    Type = model.Type,
                    CurrentPrice = currentProduct.StartingPrice
                };

                this.db.Auctions.Add(newAuction);
                this.db.SaveChanges();

                return RedirectToAction("Details", "Products", new { id = currentProduct.Id });
            }

            var ownProducts = this.db.Products
                                          .All()
                                          .Where(product => product.Owner.Id == currentUser.Id)
                                          .ToList()
                                          .Select(productEntity => new SelectListItem()
                                          {
                                              Text = productEntity.Title,
                                              Value = productEntity.Id.ToString()
                                          });

            ViewBag.OwnProducts = ownProducts;

            return View();
        }

        [Authorize]
        public ActionResult Current(Guid? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Auction currentAuction = this.db.Auctions.All().Include("Product").FirstOrDefault(auction => auction.Product.Id == productId);

            if (currentAuction == null)
            {
                return Content("There isn't auction for this product any more. Please stay tuned up, for new auctions :)");
            }

            if (DateTime.Compare(currentAuction.DateStarted.AddMinutes(currentAuction.Duration), DateTime.Now) < 0)
            {
                this.db.Auctions.Delete(currentAuction);
                this.db.SaveChanges();

                return Content("There isn't auction for this product any more. Please stay tuned up, for new auctions :)");
            }
            else
            {
                AuctionDetailedViewModel model = new AuctionDetailedViewModel
                {
                    Id = currentAuction.Id,
                    CurrentPrice = currentAuction.CurrentPrice,
                    DateStarted = currentAuction.DateStarted,
                    Product = ProductViewModel.CreateFromProduct(currentAuction.Product),
                    Type = currentAuction.Type,
                    Duration = currentAuction.Duration,
                    CurrentBuyer = currentAuction.CurrentBuyer
                };

                return View(model);
            }
        }

        [Authorize]
        public ActionResult Bid(UserBetModel currentBet)
        {
            if(ModelState.IsValid == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == userId);

            Auction currentAuction = this.db.Auctions.All().FirstOrDefault(auction => auction.Id == currentBet.AuctionId);

            if (currentAuction == null || currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User or auction doesn't exist.");
            }

            if (currentAuction.Type != AuctionType.Auction)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "This isn't an auction");
            }

            //if (currentAuction.CurrentBuyer == User.Identity.GetUserName())
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You are already current buyer.");
            //}

            if (currentAuction.CurrentPrice >= currentBet.OfferedPrice)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,
                    string.Format("You have to offer more than {0}.",
                        currentAuction.CurrentPrice.ToString("f2", CultureInfo.InvariantCulture)));
            }

            if (DateTime.Compare(DateTime.Now, currentAuction.DateStarted.AddMinutes(currentAuction.Duration)) > 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Auction already expired.");
            }
            
            Product currentProduct = db.Products.All().FirstOrDefault(product => product.Id == currentAuction.Product.Id);

            currentAuction.Product = currentProduct;
            currentAuction.CurrentBuyer = currentUser.UserName;
            currentAuction.CurrentPrice = currentBet.OfferedPrice;
            currentAuction.ParticipatingUsers.Add(currentUser);
            currentUser.CurrentAuctions.Add(currentAuction);

            this.db.Auctions.Update(currentAuction);
            this.db.Users.Update(currentUser);
            this.db.SaveChanges();


            return PartialView("_Auction", AuctionDetailedViewModel.CreateFromAuction(currentAuction));
        }

        [Authorize]
        public ActionResult GetCurrentBid(Guid? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Auction currentAuction = this.db.Auctions.All().FirstOrDefault(auction => auction.Id == id);

            if (currentAuction == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User or auction doesn't exist.");
            }


            return PartialView("_BaseAuction", AuctionDetailedViewModel.CreateFromAuction(currentAuction));
        }

        [Authorize]
        public ActionResult Buy(Guid? id)
        {

            string userId = User.Identity.GetUserId();

            Auction currentAuction = this.db.Auctions.All().FirstOrDefault(auction => auction.Id == id);

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == userId);

            if (currentAuction.Type != AuctionType.Normal || currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                this.WithdrawFrom(currentUser.CreditCard.Id, currentAuction.Product.Price);

                this.DepositTo(currentAuction.Product.Owner.CreditCard.Id, currentAuction.Product.Price);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
            
            Delivery createdDelivery = CreateDelivery(currentAuction, currentUser.UserName);

            db.Deliveries.Add(createdDelivery);

            db.Auctions.Delete(currentAuction);
            
            db.SaveChanges();

            return Content("You successfully bought a product. Please wait for its delivery");
        }

        [Authorize]
        public ActionResult CloseAuction(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Auction currentAuction = this.db.Auctions.All().FirstOrDefault(auction => auction.Id == id);

            ApplicationUser currentBuyer = this.db.Users.All().FirstOrDefault(user => user.UserName == currentAuction.CurrentBuyer);

            if (currentAuction == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Auction not found");
            }

            if (currentBuyer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Current buyer not found");
            }

            if (DateTime.Compare(currentAuction.DateStarted.AddMinutes(currentAuction.Duration), DateTime.Now) > 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            if (currentAuction.Type != AuctionType.Auction)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Delivery createdDelivery = this.CreateDelivery(currentAuction, currentAuction.CurrentBuyer);

            try
            {
                this.DepositTo(currentAuction.Product.Owner.CreditCard.Id, currentAuction.CurrentPrice);

                this.WithdrawFrom(currentBuyer.CreditCard.Id, currentAuction.CurrentPrice);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }

            createdDelivery.Products.Add(currentAuction.Product);

            db.Deliveries.Add(createdDelivery);

            db.Auctions.Delete(currentAuction);

            db.SaveChanges();

            return Content("You successfully bought a product. Please wait for its delivery");
        }

        private Delivery CreateDelivery(Auction currentAuction, string username)
        {

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.UserName == username);

            if (currentUser == null)
            {
                throw new ArgumentNullException("User not found.");
            }

            Delivery createdDelivery = new Delivery
            {
                Id = Guid.NewGuid(),
                DateShipped = DateTime.Now,
                Duration = currentAuction.DeliveryDuration,
                Receiver = currentUser,
                State = DeliveryState.Shipping
            };

            createdDelivery.Products.Add(currentAuction.Product);
            
            return createdDelivery;
        }

        private void DepositTo(Guid cardId, decimal sum)
        {
            if (cardId == null)
            {
                throw new ArgumentNullException("CardId is required");
            }

            if (sum <= 0)
            {
                throw new ArithmeticException("Sum should be positive");
            }

            CreditCard currentCard = this.db.CreditCards.GetById(cardId);

            currentCard.Funds += sum;

            currentCard.Transcations.Add(new Transaction()
            {
                Date = DateTime.Now,
                Funds = sum,
                Id = Guid.NewGuid(),
                Type = TransactionType.Deposit
            });

            this.db.CreditCards.Update(currentCard);
            this.db.SaveChanges();
        }

        private void WithdrawFrom(Guid cardId, decimal sum)
        {
            if(cardId == null)
            {
                throw new ArgumentNullException("CardId is required");
            }

            if (sum <= 0)
            {
                throw new ArithmeticException("Sum should be positive");
            }

            CreditCard currentCard = this.db.CreditCards.GetById(cardId);

            if (currentCard.Funds < sum)
            {
                throw new ArgumentOutOfRangeException("Card don't have enough funds");
            }

            currentCard.Funds -= sum;

            currentCard.Transcations.Add(new Transaction()
            {
                Date = DateTime.Now,
                Funds = sum,
                Id = Guid.NewGuid(),
                Type = TransactionType.Withdraw
            });

            this.db.CreditCards.Update(currentCard);
            this.db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}

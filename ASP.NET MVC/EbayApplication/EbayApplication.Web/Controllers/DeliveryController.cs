namespace EbayApplication.Web.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using EbayApplication.Models;
    using EbayApplication.Repositories;
    using EbayApplication.Web.Models.DeliveryModels;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class DeliveryController : Controller
    {
        private readonly IUnitOfWorkData db;

        public DeliveryController(IUnitOfWorkData db)
        {
            this.db = db;
        }

        public DeliveryController()
        {
            this.db = new UnitOfWorkData();
        }
        
        public ActionResult ByUser()
        {
            string loggedUserId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == loggedUserId);

            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IQueryable<DeliveryViewModel> deliveries = DeliveriesFromAuctions(currentUser);

            return View(deliveries);
        }
    
        public ActionResult DeliveriesByUser()
        {
            string loggedUserId = User.Identity.GetUserId();
            
            if (loggedUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You should be logged");
            }

            ApplicationUser currentUser = this.db.Users.All().FirstOrDefault(user => user.Id == loggedUserId);

            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User not found");
            }

            IQueryable<DeliveryViewModel> deliveries = DeliveriesFromAuctions(currentUser);


            return PartialView("_DeliveriesByUser", deliveries);
        }

        public ActionResult CloseDelivery(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Delivery currentDelivery = this.db.Deliveries.All().Include("Products")
                .Include("Receiver").FirstOrDefault(delivery => delivery.Id == id);

            ApplicationUser currentUser = this.db.Users.All()
                .FirstOrDefault(user => user.Id == currentDelivery.Receiver.Id);

            if (currentDelivery == null || currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            if (DateTime.Compare(DateTime.Now, currentDelivery.DateShipped.AddMinutes(currentDelivery.Duration)) > 0)
            {
                foreach (Product product in currentDelivery.Products)
                {
                    product.Owner = currentUser;
                    product.OwnerId = currentUser.Id;
                }

                currentDelivery.State = DeliveryState.Delivered;

                this.db.Users.Update(currentUser);

                this.db.Deliveries.Update(currentDelivery);

                this.db.SaveChanges();

                return Content("You successfully received products !");
            }

            return Content("Product is still shipping");
            
        }

        private IQueryable<DeliveryViewModel> DeliveriesFromAuctions(ApplicationUser currentUser)
        {
            IQueryable<DeliveryViewModel> deliveries =
                     from deliveryEntity in this.db.Deliveries.All()
                                                              .Include("Receiver")
                                                              .Where(delivery => delivery.Receiver.Id == currentUser.Id)
                                                              .OrderBy(delivery => delivery.Duration)
                                                              .ThenBy(delivery => delivery.State)
                     select new DeliveryViewModel
                     {
                         Id = deliveryEntity.Id,
                         Duration = deliveryEntity.Duration,
                         DateShipped = deliveryEntity.DateShipped,
                         State = deliveryEntity.State
                     };

            return deliveries;
        }
    }
}

using EbayApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EbayApplication.Models;
using System.Net;

namespace EbayApplication.Web.Controllers
{
    public class FundsController : Controller
    {
        
        private IUnitOfWorkData db;

        public FundsController(IUnitOfWorkData db)
        {
            this.db = db;
        }

        public FundsController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult ByUser()
        {
            string loggedUserId = User.Identity.GetUserId();

            ApplicationUser currentUser = this.db.Users.GetById(loggedUserId);

            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User not found");
            }

            var model = currentUser.CreditCard.Transcations.OrderByDescending(t => t.Date);

            ViewBag.Balance = currentUser.CreditCard.Funds;

            return View(model);
        }
	}
}
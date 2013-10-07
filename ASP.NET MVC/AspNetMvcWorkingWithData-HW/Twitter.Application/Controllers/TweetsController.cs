using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Repositories;
using Twitter.Application.Models;
using Twitter.Models;
using System.Net;

namespace Twitter.Application.Controllers
{
    public class TweetsController : Controller
    {
        private readonly IUnitOfWorkData database;

        public TweetsController()
        {
            this.database = new UnitOfWorkData();
        }

        public TweetsController(IUnitOfWorkData database)
        {
            this.database = database;
        }

        [HttpGet]
        public ActionResult All(string username)
        {
            var user = this.database.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (username != null)
            {
                user = this.database.Users.All().Include("Tweets")
                    .FirstOrDefault(usr => usr.UserName == username);
            }

            var model = ApplicationUserViewModel.CreateFromApplicationUser(user);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTweetViewModel model)
        {
            var user = this.database.Users.All()
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                var tweet = new Tweet()
                {
                    PostDate = DateTime.Now,
                    Text = model.Text,
                    User = user
                };

                this.database.Tweets.Add(tweet);
                this.database.SaveChanges();

                return RedirectToAction("All");
            }

            return View(model);
        }
    }
}
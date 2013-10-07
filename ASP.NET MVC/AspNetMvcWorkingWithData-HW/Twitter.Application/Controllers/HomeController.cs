using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Application.Models;
using Twitter.Repositories;

namespace Twitter.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkData database;

        public HomeController()
        {
            this.database = new UnitOfWorkData();
        }

        public HomeController(IUnitOfWorkData database)
        {
            this.database = database;
        }

        public ActionResult Index()
        {
            var users = this.database.Users.All()
                .Select(ApplicationUserViewModel.FromApplicationUser.Compile());

            return View(users);
        }
    }
}
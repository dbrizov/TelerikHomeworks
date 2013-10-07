using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Web.Models;

namespace LaptopSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            : base()
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["laptops"] == null)
            {
                var laptops = this.data.Laptops.All()
                    .OrderByDescending(laptop => laptop.Votes.Count())
                    .Take(6)
                    .Select(LaptopViewModel.FromLaptop)
                    .ToList();

                this.HttpContext.Cache.Add("laptops", laptops, null, DateTime.Now.AddHours(1), 
                    TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["laptops"]);
        }
    }
}
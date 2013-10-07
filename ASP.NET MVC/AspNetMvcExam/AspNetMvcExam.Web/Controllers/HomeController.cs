using System;
using System.Linq;
using System.Web.Mvc;
using AspNetMvcExam.Web.Models;

namespace AspNetMvcExam.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            : base()
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["tickets"] == null)
            {
                var tickets = this.data.Tickets.All()
                    .OrderByDescending(t => t.Comments.Count())
                    .Take(6)
                    .Select(TicketViewModel.FromTicket);

                this.HttpContext.Cache["tickets"] = tickets.ToList();
            }

            return View(this.HttpContext.Cache["tickets"]);
        }
    }
}
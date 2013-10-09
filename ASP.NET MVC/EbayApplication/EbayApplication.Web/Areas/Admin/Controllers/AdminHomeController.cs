using System;
using System.Linq;
using System.Web.Mvc;

namespace EbayApplication.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminHomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
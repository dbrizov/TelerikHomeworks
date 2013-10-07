using System;
using System.Linq;
using System.Web.Mvc;

namespace LaptopSystem.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : BaseController
    {
        public AdminController()
            : base()
        {
        }
    }
}
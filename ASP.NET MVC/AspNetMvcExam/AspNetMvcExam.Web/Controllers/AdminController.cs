using System;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcExam.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController()
            : base()
        {
        }
    }
}
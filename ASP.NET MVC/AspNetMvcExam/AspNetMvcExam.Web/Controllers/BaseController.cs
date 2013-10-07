using AspNetMvcExam.Data;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcExam.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWorkData data;

        public BaseController()
        {
            this.data = new UnitOfWorkData();
        }
    }
}
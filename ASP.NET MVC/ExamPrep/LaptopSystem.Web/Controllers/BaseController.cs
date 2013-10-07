using LaptopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopSystem.Web.Controllers
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
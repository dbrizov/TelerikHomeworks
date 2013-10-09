using EbayApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EbayApplication.Web.Models
{
    public class UserProductsSelectListModel
    {
        public IEnumerable<SelectListItem> Products { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
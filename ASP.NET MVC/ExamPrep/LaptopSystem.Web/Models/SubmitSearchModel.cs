using System;
using System.Linq;

namespace LaptopSystem.Web.Models
{
    public class SubmitSearchModel
    {
        public string ModelQuery { get; set; }

        public string ManufacturerQuery { get; set; }

        public decimal PriceQuery { get; set; }
    }
}
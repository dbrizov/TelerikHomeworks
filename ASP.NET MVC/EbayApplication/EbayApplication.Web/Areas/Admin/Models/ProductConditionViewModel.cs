using System;
using System.Linq;

namespace EbayApplication.Web.Areas.Admin.Models
{
    public class ProductConditionViewModel
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public ProductConditionViewModel(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
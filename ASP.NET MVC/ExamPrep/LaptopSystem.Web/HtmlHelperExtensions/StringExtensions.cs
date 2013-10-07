using System;
using System.Linq;
using System.Web.Mvc;

namespace LaptopSystem.Web.HtmlHelperExtensions
{
    public static class StringExtensions
    {
        public static string CutLongString(this HtmlHelper helper,
            int size, string input)
        {
            if (input.Length > 20)
            {
                input = input.Substring(0, 20) + "…";
            }

            return input;
        }
    }
}
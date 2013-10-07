using System;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcExam.Web.HtmlHelperExtensions
{
    public static class StringExtensions
    {
        public static string CutLongString(this HtmlHelper helper,
            string input, int resultLength)
        {
            string result = string.Empty;
            if (input.Length > resultLength)
            {
                result = input.Substring(0, resultLength) + "…";
            }

            return result;
        }
    }
}
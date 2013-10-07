using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvcExam.Web.CustomAttributes
{
    public class ShouldNotContainTheWordBugAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            valueAsString = valueAsString.ToLower();

            if (valueAsString.Contains("bug"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
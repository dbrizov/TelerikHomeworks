using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace LaptopSystem.Models.CustomAttributes
{
    public class ShouldNotContainEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (Regex.IsMatch(valueAsString, @"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,4}"))
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

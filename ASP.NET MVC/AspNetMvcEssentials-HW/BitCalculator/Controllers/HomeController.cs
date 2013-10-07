using BitCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<string> types = new List<string>()
        {
            "bit - b",
            "Byte - B",
            "Kilobit - Kb",
            "Kilobyte - KB",
            "Megabit - Mb",
            "Megabyte - MB",
            "Gigabit - Gb",
            "Gigabyte - GB",
            "Terabit - Tb",
            "Terabyte - TB",
            "Petabit - Pb",
            "Petabyte - PB",
            "Exabit - Eb",
            "Exabyte - EB",
            "Zettabit - Zb",
            "Zettabyte - ZB",
            "Yottabit - Yb",
            "Yottabyte - YB"
        };

        private readonly List<SelectListItem> kilosDropDown;
        private readonly List<SelectListItem> typesDropDown;

        public HomeController()
        {
            this.kilosDropDown = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "1000", Value = "1000" },
                new SelectListItem() { Text = "1024", Value = "1024", Selected = true }
            };

            this.typesDropDown = new List<SelectListItem>();
            foreach (var type in this.types)
            {
                typesDropDown.Add(new SelectListItem()
                {
                    Text = type
                });
            }

            this.ViewBag.KilosDropDown = this.kilosDropDown;
            this.ViewBag.TypesDropDown = this.typesDropDown;
            this.ViewData["typesDropDown"] = this.typesDropDown;
        }

        public ActionResult Results(string quantity, string type, string kilo)
        {
            var results = new ResultViewModel[18];
            for (int i = 0; i < this.types.Count; i++)
            {
                results[i] = new ResultViewModel()
                {
                    Type = this.types[i]
                };
            }

            if (quantity == null || type == null || kilo == null)
            {
                return View(results);
            }

            int indexOfSelectedType = this.types.IndexOf(type);
            double quantityAsDouble = double.Parse(quantity);
            bool isBase1024 = (kilo == "1024");
            bool isByteTypeChosen = (indexOfSelectedType % 2 != 0);

            // Calculate the lesser types
            CalculateLesserTypes(indexOfSelectedType, isByteTypeChosen, isBase1024, quantityAsDouble, results);

            // Calculating the greater types
            CalculateGreaterTypes(indexOfSelectedType, isByteTypeChosen, isBase1024, quantityAsDouble, results);

            // Calculating the selected type
            if (isByteTypeChosen)
            {
                results[indexOfSelectedType - 1].Value = quantityAsDouble * 8;
                results[indexOfSelectedType].Value = quantityAsDouble;
            }
            else
            {
                results[indexOfSelectedType].Value = quantityAsDouble;
                results[indexOfSelectedType + 1].Value = quantityAsDouble / 8;
            }

            return View(results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void CalculateLesserTypes(int indexOfSelectedType, bool isByteTypeChosen,
            bool isBase1024, double quantityAsDouble, ResultViewModel[] results)
        {
            for (int i = 0; i < indexOfSelectedType; i += 2)
            {
                if (isByteTypeChosen)
                {
                    results[i].Value = quantityAsDouble * 8;
                    results[i + 1].Value = quantityAsDouble;
                }
                else
                {
                    results[i].Value = quantityAsDouble;
                    results[i + 1].Value = quantityAsDouble / 8;
                }

                int iterations = (indexOfSelectedType - i) / 2;
                for (int j = 0; j < iterations; j++)
                {
                    if (isBase1024)
                    {
                        results[i].Value *= 1024;
                        results[i + 1].Value *= 1024;
                    }
                    else
                    {
                        results[i].Value *= 1000;
                        results[i + 1].Value *= 1000;
                    }
                }
            }
        }

        private void CalculateGreaterTypes(int indexOfSelectedType, bool isByteTypeChosen,
            bool isBase1024, double quantityAsDouble, ResultViewModel[] results)
        {
            int startIndex = 0;
            if (isByteTypeChosen)
            {
                startIndex = indexOfSelectedType + 1;
            }
            else
            {
                startIndex = indexOfSelectedType + 2;
            }

            for (int i = startIndex; i < results.Length - 1; i += 2)
            {
                if (isByteTypeChosen)
                {
                    results[i].Value = quantityAsDouble * 8;
                    results[i + 1].Value = quantityAsDouble;
                }
                else
                {
                    results[i].Value = quantityAsDouble;
                    results[i + 1].Value = quantityAsDouble / 8;
                }

                int iterations = (i - startIndex) / 2 + 1;
                for (int j = 0; j < iterations; j++)
                {
                    if (isBase1024)
                    {
                        results[i].Value /= 1024;
                        results[i + 1].Value /= 1024;
                    }
                    else
                    {
                        results[i].Value /= 1000;
                        results[i + 1].Value /= 1000;
                    }
                }
            }
        }
    }
}
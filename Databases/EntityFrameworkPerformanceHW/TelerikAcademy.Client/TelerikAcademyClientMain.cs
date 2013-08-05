using System;
using System.Linq;
using TelerikAcademy.Data;

namespace TelerikAcademy.Client
{
    public class TelerikAcademyClientMain
    {
        public static void Main(string[] args)
        {
            //PrintEmployeesSlow();
            //PrintEmployeesFast();
            //FindEmployeesByTownSlow("Sofia");
            FindEmployeesByTownFast("Sofia");
        }

        // Task 1 - Using Entity Framework write a SQL query to select all employees from the Telerik Academy 
        // database and later print their name, department and town. Try the both variants: with and without .Include(…).
        // Compare the number of executed SQL statements and the performance.
        public static void PrintEmployeesSlow()
        {
            TelerikAcademyEntities telerikAcademyDb = new TelerikAcademyEntities();
            using (telerikAcademyDb)
            {
                var employees = telerikAcademyDb.Employees;
                foreach (var employee in employees)
                {
                    Console.WriteLine("Employee: {0}, {1}, {2}", employee.FirstName, employee.Department, employee.Address.Town);
                }
            }
        }

        public static void PrintEmployeesFast()
        {
            TelerikAcademyEntities telerikAcademyDb = new TelerikAcademyEntities();
            using (telerikAcademyDb)
            {
                var employees = telerikAcademyDb.Employees.Include("Department").Include("Address").Include("Address.Town");
                foreach (var employee in employees)
                {
                    Console.WriteLine("Employee: {0}, {1}, {2}", employee.FirstName, employee.Department, employee.Address.Town);
                }
            }
        }

        // Task 2 - Using Entity Framework write a query that selects all employees from the Telerik Academy database,
        // then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns,
        // then invokes ToList() and finally checks whether the town is "Sofia".
        // Rewrite the same in more optimized way and compare the performance.

        public static void FindEmployeesByTownSlow(string townName)
        {
            TelerikAcademyEntities telerikAcademyDb = new TelerikAcademyEntities();
            using (telerikAcademyDb)
            {
                var towns = telerikAcademyDb.Employees.ToList()
                    .Select(employee => employee.Address).ToList()
                    .Select(address => address.Town).ToList()
                    .Where(town => town.Name == townName).ToList();

                for (int i = 0; i < towns.Count; i++)
                {
                    Console.WriteLine("Town: {0}", towns[0].Name);
                }

                Console.WriteLine("There are {0} employees that leave in {1}", towns.Count, townName);
            }
        }

        public static void FindEmployeesByTownFast(string townName)
        {
            TelerikAcademyEntities telerikAcademyDb = new TelerikAcademyEntities();
            using (telerikAcademyDb)
            {
                var towns = telerikAcademyDb.Employees
                    .Select(employee => employee.Address)
                    .Select(address => address.Town)
                    .Where(town => town.Name == townName).ToList();

                for (int i = 0; i < towns.Count; i++)
                {
                    Console.WriteLine("Town: {0}", towns[0].Name);
                }

                Console.WriteLine("There are {0} employees that leave in {1}", towns.Count, townName);
            }
        }
    }
}

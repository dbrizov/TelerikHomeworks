using System;
using System.Linq;
using Northwind.Data;

namespace Northwind.Client
{
    public static class NorthwindDAO
    {
        // Task 2 - Create a DAO class with static methods which provide functionality for 
        // inserting, modifying and deleting customers. Write a testing class.
        public static void AddCustomer(
            string companyName,
            string contactName,
            string contactTitle,
            string address,
            string city,
            string region,
            string postalCode,
            string country,
            string phone,
            string fax)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                string customerID = string.Format("{0}{1}{2}{3}{4}", companyName[0], contactName[0], contactTitle[0], city[0], country[0]);

                Customer customer = new Customer()
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                northwindDb.Customers.Add(customer);
                northwindDb.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                Customer customer = northwindDb.Customers.Find(customerID);
                northwindDb.Customers.Remove(customer);
                northwindDb.SaveChanges();
            }
        }

        public static void ModifyCustomer(string customerID, string companyName)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                Customer customer = northwindDb.Customers.Find(customerID);
                customer.CompanyName = companyName;
                northwindDb.SaveChanges();
            }
        }

        // Task 3 - Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static void FindCustomers(int year, string country)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                /* With LINQ */
                var result =
                    from customer in northwindDb.Customers
                    join order in northwindDb.Orders
                    on customer.CustomerID equals order.CustomerID
                    where order.ShipCountry == country && order.OrderDate.Value.Year == year
                    select new
                    {
                        CustomerID = customer.CustomerID,
                        OrderDate = order.OrderDate,
                        ShipCountry = order.ShipCountry
                    };

                /* With Extension methods */
                //var result = northwindDb.Customers.Join(
                //    northwindDb.Orders,
                //    (customer => customer.CustomerID),
                //    (order => order.CustomerID),
                //    (customer, order) => new
                //    {
                //        CustomerID = customer.CustomerID,
                //        OrderDate = order.OrderDate,
                //        ShipCountry = order.ShipCountry
                //    }).Where(order => order.ShipCountry == country && order.OrderDate.Value.Year == year);

                foreach (var item in result)
                {
                    Console.WriteLine(string.Format("{0}, {1}, {2}",
                        item.CustomerID, item.OrderDate, item.ShipCountry));
                }
            }
        }

        // Task 4 - Implement previous by using native SQL query and executing it through the DbContext.
        public static void FindCustomersNativeSqlQuery(int orderDate, string country)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                string sqlQuery =
                    "SELECT CONCAT(c.CustomerID, ', ', o.OrderDate, ', ', o.ShipCountry) " +
                    "FROM Customers c " +
                    "JOIN Orders o ON o.CustomerID = c.CustomerID " +
                    "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

                object[] parameters = { orderDate, country };
                var sqlQueryResult = northwindDb.Database.SqlQuery<string>(sqlQuery, parameters);

                foreach (var item in sqlQueryResult)
                {
                    Console.WriteLine(item);
                }
            }
        }

        // Task 5 - Write a method that finds all the sales by specified region and period (start / end dates).
        public static void FindSales(string region, DateTime startDate, DateTime endDate)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                var sales =
                    from order in northwindDb.Orders
                    where
                        order.ShipRegion == region &&
                        order.OrderDate == startDate &&
                        order.ShippedDate == endDate
                    select new
                    {
                        ShipRegion = order.ShipRegion,
                        StartDate = order.OrderDate,
                        EndDate = order.ShippedDate
                    };

                foreach (var sale in sales)
                {
                    Console.WriteLine(string.Format("Region: {0}, StartDate: {1}, EndDate: {2}",
                        sale.ShipRegion, sale.StartDate, sale.EndDate));
                }
            }
        }

        // Task 6 - Create a database called NorthwindTwin with the same structure as Northwind
        // using the features from DbContext. Find for the API for schema generation in MSDN or in Google.

        // Task 9 - Create a method that places a new order in the Northwind database. 
        // The order should contain several order items. Use transaction to ensure the data consistency.
        public static void AddOrder(
            string customerID,
            int? employeeID,
            DateTime? orderDate,
            DateTime? requiredDate,
            DateTime? shippedDate,
            int? shipVia,
            decimal? freight,
            string shipName,
            string shipAddress,
            string shipCity,
            string shipRegion,
            string shipPostalCode,
            string shipCountry)
        {
            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                Order newOrder = new Order()
                {
                    CustomerID = customerID,
                    EmployeeID = employeeID,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    ShippedDate = shippedDate,
                    ShipVia = shipVia,
                    Freight = freight,
                    ShipName = shipName,
                    ShipAddress = shipAddress,
                    ShipCity = shipCity,
                    ShipRegion = shipRegion,
                    ShipPostalCode = shipPostalCode,
                    ShipCountry = shipCountry
                };

                northwindDb.Orders.Add(newOrder);
                northwindDb.SaveChanges();
            }
        }

        // Task 10 - Create a stored procedures in the Northwind database for finding the
        // total incomes for given supplier name and period (start date, end date).
        // Implement a C# method that calls the stored procedure and returns the retuned record set.
        public static System.Data.Objects.ObjectResult<decimal?> GetTotalIncome(DateTime? startDate, DateTime? endDate, string companyName)
        {
            System.Data.Objects.ObjectResult<decimal?> result = null;

            NorthwindEntities northwindDb = new NorthwindEntities();
            using (northwindDb)
            {
                result = northwindDb.usp_GetTotalIncome(startDate, endDate, companyName);
            }

            return result;
        }
    }
}

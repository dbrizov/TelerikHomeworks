using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Northwind.Client
{
    public class NorthwindClientMain
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // --------------- Task 2 Demo ---------------
            //NorthwindDAO.AddCustomer("Telerik", "ContactName", "ContactTitle", "Address", "Sofia",
            //    "Sofia", "PostalCode", "Bulgaria", "0889 123 456", "Fax");

            //NorthwindDAO.DeleteCustomer("TCCSB");

            //NorthwindDAO.ModifyCustomer("TCCSB", "SomeCompanyName");

            // --------------- Task 3 Demo ---------------
            //NorthwindDAO.FindCustomers(1997, "Canada");

            // --------------- Task 4 Demo ---------------
            //NorthwindDAO.FindCustomersNativeSqlQuery(1997, "Canada");

            // --------------- Task 5 Demo ---------------
            //string region = "Co. Cork";
            //DateTime startDate = DateTime.Parse("1996-09-05 00:00:00.000");
            //DateTime endDate = DateTime.Parse("1996-09-11 00:00:00.000");

            //NorthwindDAO.FindSales(region, startDate, endDate);

            // --------------- Task 6 Demo ---------------
            // Go to the diagram -> right click somewhere -> Generate Database From Model

            // --------------- Task 7 Demo ---------------
            // Try to open two different data contexts and perform concurrent changes on the same records. 
            // What will happen at SaveChanges()? How to deal with it?
            // You can read more about it here http://msdn.microsoft.com/en-us/library/vstudio/bb738618%28v=vs.100%29.aspx

            // --------------- Task 8 Demo ---------------
            // See the Extender class in the Northwind.Data namespace

            // --------------- Task 9 Demo ---------------
            //NorthwindDAO.AddOrder(null, null, null, null, null, null, null, null, null, null, null, null, null);

            // --------------- Task 10 Demo ---------------
            //DateTime startDate = DateTime.Parse("1990-09-05 00:00:00.000");
            //DateTime endDate = DateTime.Parse("2000-09-11 00:00:00.000");
            //string companyName = "Exotic Liquids";

            //Console.WriteLine(NorthwindDAO.GetTotalIncome(startDate, endDate, companyName));
            //Console.WriteLine("I don't know how I am supposed to cast it to decimal");
        }
    }
}

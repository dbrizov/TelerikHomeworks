using System;
using System.Linq;
using System.Data.SqlClient;

namespace ProductCategories
{
    class ProductsCategoriesNames
    {
        static void Main(string[] args)
        {
            const string ConnectionString =
                "Server=localhost; Database=Northwind; Integrated Security=true";

            SqlConnection sqlDBCon = new SqlConnection(ConnectionString);
            sqlDBCon.Open();

            using (sqlDBCon)
            {
                string queryText =
                    "SELECT c.CategoryName, p.ProductName FROM " +
                    "Categories c JOIN Products p " +
                    "ON c.CategoryID = p.CategoryID " +
                    "ORDER BY c.CategoryName";

                SqlCommand sqlCmd = new SqlCommand(queryText, sqlDBCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("{0,-15}:  {1}", "CategoryName", "ProductName");
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("{0,-15}:  {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}

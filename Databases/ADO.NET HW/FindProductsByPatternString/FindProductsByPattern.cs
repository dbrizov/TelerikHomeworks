using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FindProductsByPatternString
{
    class FindProductsByPattern
    {
        static List<string> FindProducts(SqlConnection sqlDbCon, string pattern)
        {
            List<string> products = new List<string>();

            string cmdText = "SELECT ProductName FROM Products WHERE ProductName LIKE @pattern { ESCAPE '\\' }";
            SqlCommand cmdFindProducts = new SqlCommand(cmdText, sqlDbCon);

            StringBuilder escapedPattern = new StringBuilder();
            for (int i = 0; i < pattern.Length; i++)
            {
                escapedPattern.Append("\\");
                escapedPattern.Append(pattern[i]);
            }

            cmdFindProducts.Parameters.AddWithValue("@pattern", "%" + escapedPattern.ToString() + "%");

            SqlDataReader reader = cmdFindProducts.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string product = (string)reader["ProductName"];
                    products.Add(product);
                }
            }

            return products;
        }

        static void Main(string[] args)
        {
            const string ConnectionString =
                "Server=localhost; Database=Northwind; Integrated Security=true";
            SqlConnection sqlDbCon = new SqlConnection(ConnectionString);
            sqlDbCon.Open();

            using (sqlDbCon)
            {
                Console.Write("Enter pattern: ");
                string pattern = Console.ReadLine();

                List<string> products = FindProducts(sqlDbCon, pattern);
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}

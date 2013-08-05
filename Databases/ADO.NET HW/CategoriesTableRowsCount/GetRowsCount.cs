using System;
using System.Linq;
using System.Data.SqlClient;

namespace CategoriesTableRowsCount
{
    class GetRowsCount
    {
        static void Main(string[] args)
        {
            const string ConnectionString =
                @"Server=localhost\SQLEXPRESS; Database=Northwind; Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                string getRowsCountQuery = "SELECT COUNT(*) FROM Categories";
                SqlCommand sqlCommand = new SqlCommand(getRowsCountQuery, sqlConnection);
                int rowsCount = (int)sqlCommand.ExecuteScalar();
                Console.WriteLine(rowsCount);
            }
        }
    }
}

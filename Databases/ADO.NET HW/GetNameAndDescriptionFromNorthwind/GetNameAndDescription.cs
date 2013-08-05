using System;
using System.Linq;
using System.Data.SqlClient;

namespace GetNameAndDescriptionFromNorthwind
{
    class GetNameAndDescription
    {
        static void Main(string[] args)
        {
            const string ConnectionString =
                "Server=localhost; Database=Northwind; Integrated Security=true";

            SqlConnection sqlDBConnection = new SqlConnection(ConnectionString);
            sqlDBConnection.Open();

            using (sqlDBConnection)
            {
                string getNameAndDescriptionQuery = "SELECT CategoryName, Description FROM Categories";

                SqlCommand getNameAndDescriptionCommand = new SqlCommand(getNameAndDescriptionQuery, sqlDBConnection);
                SqlDataReader reader = getNameAndDescriptionCommand.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];

                        Console.WriteLine("{0, -15}: {1}", name, description);
                    }
                }
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.IO;

namespace RetrieveImagesFromDB
{
    class GetImagesFromDB
    {
        static void Main()
        {
            const string FilePath = "..\\..\\";
            const string FileExtension = ".jpg";
            const string ConnectionString = "Server=localhost; Database=Northwind; Integrated Security=true";

            SqlConnection sqlDBCon = new SqlConnection(ConnectionString);
            RetrieveImagesFromSqlDB(sqlDBCon, FilePath, FileExtension);
        }
 
        static void RetrieveImagesFromSqlDB(SqlConnection sqlDBCon, string filePath, string fileExtension)
        {
            sqlDBCon.Open();
            using (sqlDBCon)
            {
                string queryText = "SELECT Picture, CategoryName FROM Categories";

                SqlCommand cmd = new SqlCommand(queryText, sqlDBCon);
               
                SqlDataReader reader = cmd.ExecuteReader();
 
                using (reader)
                {
                    byte[] image;
                    string categoryName;
                    while(reader.Read())
                    {                        
                        image = (byte[])reader["Picture"];
                        categoryName = reader["CategoryName"].ToString().Replace('/', '.');
                        CreateBinaryFile(image, filePath + categoryName + fileExtension);
                        image = null;
                    }
                }
            }
        }
 
        static void CreateBinaryFile(byte[] fileData, string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Create);
            using (stream)
            {
                int headerLength = 78; // The Northwind images have a header with length 78. It's not needed so we just skip it
                stream.Write(fileData, headerLength, fileData.Length - headerLength);
            }
        }
    }
}

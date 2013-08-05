using System;
using System.Data.OleDb;

namespace AddRowToTable
{
    class AddRowToExcelTable
    {
        static int InsertRow(OleDbConnection oleDbCon, string name, int score)
        {
            string cmdText = "INSERT INTO [Sheet1$] (Name, Score) VALUES (@name, @score)";
            OleDbCommand cmdInsertRow = new OleDbCommand(cmdText, oleDbCon);
            cmdInsertRow.Parameters.AddWithValue("@name", name);
            cmdInsertRow.Parameters.AddWithValue("@score", score);

            int result = cmdInsertRow.ExecuteNonQuery();
            return result;
        }

        static void Main(string[] args)
        {
            const string ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=..\\..\\table.xlsx; Extended Properties=Excel 12.0 Xml;";

            OleDbConnection oleDbCon = new OleDbConnection(ConnectionString);
            oleDbCon.Open();

            using (oleDbCon)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Score: ");
                int score = int.Parse(Console.ReadLine());

                InsertRow(oleDbCon, name, score);
            }
        }
    }
}

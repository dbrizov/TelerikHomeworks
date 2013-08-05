using System;
using System.Data;
using System.Data.OleDb;

namespace ReadFromExcelFile
{
    class ReadExcelFile
    {
        static void Main(string[] args)
        {
            const string ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=..\\..\\table.xlsx; Extended Properties=Excel 12.0 Xml;";

            OleDbConnection oleDbCon = new OleDbConnection(ConnectionString);
            oleDbCon.Open();

            using (oleDbCon)
            {
                DataTable dataTable = new DataTable();

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oleDbCon);
                using (dataAdapter)
                {
                    dataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine("{0, -17}: {1}", row.ItemArray[0], row.ItemArray[1]);
                    }
                }
            }
        }
    }
}

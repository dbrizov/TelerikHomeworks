using System;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;

namespace SQLiteDataProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            const string ConnectionString = "Data Source=..\\..\\Library.db";
            SQLiteConnection sqliteConnection = new SQLiteConnection(ConnectionString);

            Console.WriteLine("ADD BOOK");
            AddBook(sqliteConnection, "Author", "Title", DateTime.Now, "9812-54-67");

            Console.WriteLine("\nLIST ALL BOOKS");
            ListAllBooks(sqliteConnection);

            Console.WriteLine("\nFIND BOOK BY TITLE");
            Console.WriteLine(FindBook(sqliteConnection, "My Book"));
        }

        static int AddBook(SQLiteConnection sqliteConnection, string author, string title, DateTime publishDate, string isbn)
        {
            int rowsAffected = 0;

            sqliteConnection.Open();

            string commandText =
                "INSERT INTO Books (Author, Title, PublishDate, ISBN) " +
                "VALUES (@author, @title, @publishDate, @isbn)";

            SQLiteCommand cmdAddBook = new SQLiteCommand(commandText, sqliteConnection);
            cmdAddBook.Parameters.AddWithValue("@author", author);
            cmdAddBook.Parameters.AddWithValue("@title", title);
            cmdAddBook.Parameters.AddWithValue("@isbn", isbn);
            cmdAddBook.Parameters.AddWithValue("@publishDate", publishDate);

            rowsAffected = cmdAddBook.ExecuteNonQuery();

            sqliteConnection.Close();

            return rowsAffected;
        }

        static void ListAllBooks(SQLiteConnection sqliteConnection)
        {
            sqliteConnection.Open();

            string commandText = "SELECT Author, Title, PublishDate, ISBN FROM Books";

            SQLiteCommand cmdListAllBooks = new SQLiteCommand(commandText, sqliteConnection);

            SQLiteDataReader reader = cmdListAllBooks.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string author = (string)reader["Author"];
                    string title = (string)reader["Title"];
                    string isbn = (string)reader["ISBN"];
                    DateTime publishDate = publishDate = (DateTime)reader["PublishDate"];

                    Console.WriteLine("{0}, {1}, {2}, {3}", author, title, publishDate, isbn);
                }
            }

            sqliteConnection.Close();
        }

        static string FindBook(SQLiteConnection sqliteConnection, string title)
        {
            string result = string.Empty;

            sqliteConnection.Open();

            string commandText =
                "SELECT DISTINCT Author, Title, PublishDate, ISBN " +
                "FROM Books " +
                "WHERE Title = @title";

            SQLiteCommand cmdFindBook = new SQLiteCommand(commandText, sqliteConnection);
            cmdFindBook.Parameters.AddWithValue("@title", title);

            SQLiteDataReader reader = cmdFindBook.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string author = (string)reader["Author"];
                    string bookTitle = (string)reader["Title"];
                    string isbn = (string)reader["ISBN"];
                    DateTime publishDate = publishDate = (DateTime)reader["PublishDate"];

                    result = string.Format("{0}, {1}, {2}, {3}", author, title, publishDate, isbn);
                }
            }

            sqliteConnection.Close();

            return result;
        }
    }
}

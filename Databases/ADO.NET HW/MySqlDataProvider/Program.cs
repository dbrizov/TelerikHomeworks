using System;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace MySqlDataProvider
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            const string ConnectionString =
                "Server=localhost; Port=3306; Database=library; Uid=root; Pwd=a9f001e55;";
            MySqlConnection mySqlDbCon = new MySqlConnection(ConnectionString);

            Console.WriteLine("ADD BOOK");
            AddBook("MyBook", "Me", DateTime.Now, "123456789", mySqlDbCon);

            Console.WriteLine("\nFIND BOOK BY TITLE");
            FindBook("MyBook", mySqlDbCon);

            Console.WriteLine("\nLIST ALL BOOKS");
            ListAllBooks(mySqlDbCon);
        }

        static void AddBook(string title, string author, DateTime publishDate, string isbn, MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();

            string commandText =
                "INSERT INTO books (Title, Author, PublishDate, ISBN) " +
                "VALUES (@title, @author, @publishDate, @isbn)";
            MySqlCommand cmdAddBook =
                new MySqlCommand(commandText, mySqlConnection);

            cmdAddBook.Parameters.AddWithValue("@title", title);
            cmdAddBook.Parameters.AddWithValue("@author", author);
            cmdAddBook.Parameters.AddWithValue("@publishDate", publishDate);
            cmdAddBook.Parameters.AddWithValue("@isbn", isbn);

            cmdAddBook.ExecuteNonQuery();

            mySqlConnection.Close();
        }

        static void FindBook(string bookTitle, MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();

            string commandText = "SELECT DISTINCT Author, Title, PublishDate FROM books WHERE Title=@bookTitle";
            MySqlCommand cmdFindBook = new MySqlCommand(commandText, mySqlConnection);

            cmdFindBook.Parameters.AddWithValue("@bookTitle", bookTitle);

            var reader = cmdFindBook.ExecuteReader();
            while (reader.Read())
            {
                string author = (string)reader["Author"];
                string title = (string)reader["Title"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string isbn = (string)reader["ISBN"];

                Console.WriteLine("{0}, {1}, {2}, {3}", title, author, publishDate, isbn);
            }

            mySqlConnection.Close();
        }


        static void ListAllBooks(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();

            string commandText = "SELECT Author, Title, PublishDate, ISBN FROM Books";
            MySqlCommand command = new MySqlCommand(commandText, mySqlConnection);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string author = (string)reader["Author"];
                string title = (string)reader["Title"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string isbn = (string)reader["ISBN"];

                Console.WriteLine("{0}, {1}, {2}, {3}", title, author, publishDate, isbn);
            }

            mySqlConnection.Close();
        }
    }
}

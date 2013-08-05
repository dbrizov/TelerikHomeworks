using System;
using System.Linq;
using System.Text;
using Bookmarks.Data;

namespace BulkDataGenerator
{
    public class BulkDataGeneratorMain
    {
        public const int MaxSqlInsrtRows = 500;
        public const int UsersCount = 30000;
        public const int BookmarksCount = 200000;
        public const int TagsCount = 10000;

        public static void Main(string[] args)
        {
            ClearTables();
            InsertUsers(UsersCount);
            InsertBookmarks(BookmarksCount);
        }

        private static void InsertBookmarks(int bookmarksCount)
        {
            throw new NotImplementedException();
        }

        private static void InsertUsers(int usersCount)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("INSERT INTO Users (Username) VALUES ");

            int count = 0;
            while (count < UsersCount)
            {
                for (int i = count; i < MaxSqlInsrtRows + count; i++)
                {
                    sqlCommand.Append("('user" + i + "'),");
                }

                sqlCommand.Length--;

                BookmarksEntities context = new BookmarksEntities();
                using (context)
                {
                    context.Database.ExecuteSqlCommand(sqlCommand.ToString());
                    sqlCommand.Clear();
                    sqlCommand.Append("INSERT INTO Users (Username) VALUES ");
                }

                count += 500;
            }
        }

        private static void ClearTables()
        {
            BookmarksEntities context = new BookmarksEntities();
            string commandText =
                "DELETE FROM Bookmarks_Tags " +
                "DELETE FROM Bookmarks " +
                "DELETE FROM Tags " +
                "DELETE FROM Users " +

                "DBCC CHECKIDENT (Bookmarks, reseed, 0) " +
                "DBCC CHECKIDENT (Tags, reseed, 0) " +
                "DBCC CHECKIDENT (Users, reseed, 0)";

            context.Database.ExecuteSqlCommand(commandText);
        }
    }
}

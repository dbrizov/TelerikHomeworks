using System;
using System.Linq;
using Bookmarks.Data;

namespace BookmarksImporter
{
    public class ImporterMain
    {
        static void Main(string[] args)
        {
            string bookmarksXmlPath = @"..\..\bookmarks.xml";
            BookmarksDAO.ImportXmlIntoDatabase(bookmarksXmlPath);
        }
    }
}

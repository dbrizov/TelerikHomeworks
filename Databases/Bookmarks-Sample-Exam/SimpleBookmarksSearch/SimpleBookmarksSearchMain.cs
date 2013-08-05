using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Bookmarks.Data;

namespace SimpleBookmarksSearch
{
    public class SimpleBookmarksSearchMain
    {
        static void Main(string[] args)
        {
            BookmarksEntities context = new BookmarksEntities();
            using (context)
            {
                string simpleSearchXmlPath = @"..\..\simple-query.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(simpleSearchXmlPath);
                string xpathQuery = "query";

                XmlNode bookmarkNode = doc.SelectSingleNode(xpathQuery);

                string username = null;
                XmlNode usernameNode = bookmarkNode.SelectSingleNode("username");
                if (usernameNode != null)
                {
                    username = usernameNode.InnerText;
                }

                string tag = null;
                XmlNode tagNode = bookmarkNode.SelectSingleNode("tag");
                if (tagNode != null)
                {
                    tag = tagNode.InnerText;
                }

                IEnumerable<Bookmark> bookmarks = BookmarksDAO.FindBookmarksByUsernameAndTag(context, username, tag);
                if (bookmarks.Count() > 0)
                {
                    foreach (var bookmark in bookmarks)
                    {
                        Console.WriteLine(bookmark.URL);
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
            }
        }
    }
}

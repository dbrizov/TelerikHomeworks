using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Bookmarks.Data;

namespace ComplexBookmarksSearch
{
    public static class ComplexBookmarksSearchMain
    {
        public static void Main(string[] args)
        {
            BookmarksEntities context = new BookmarksEntities();
            using (context)
            {
                string fileName = @"..\..\search-results.xml";
                using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("search-results");

                    string complexSearchXmlPath = @"..\..\complex-query.xml";
                    ProcessSearchQueries(writer, complexSearchXmlPath);

                    writer.WriteEndDocument();
                }
            }
        }

        private static void ProcessSearchQueries(XmlTextWriter writer, string complexSearchXmlPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(complexSearchXmlPath);

            string xpathQuery = "queries/query";
            XmlNodeList queryNodes = doc.SelectNodes(xpathQuery);
            foreach (XmlNode queryNode in queryNodes)
            {
                string username = queryNode.GetChildText("username");
                int maxResults = 10;
                XmlAttribute maxResultsAttribute = queryNode.Attributes["max-results"];
                if (maxResultsAttribute != null)
                {
                    maxResults = int.Parse(maxResultsAttribute.InnerText);
                }

                List<string> tags = new List<string>();
                foreach (XmlNode tag in queryNode.SelectNodes("tag"))
                {
                    tags.Add(tag.InnerText.Trim());
                }

                var bookmarks = BookmarksDAO.FindBookmarks(username, tags, maxResults);

                WriteBookmark(writer, bookmarks);
            }
        }

        private static void WriteBookmark(XmlTextWriter writer, IList<Bookmark> bookmarks)
        {
            writer.WriteStartElement("result-set");

            foreach (var bookmark in bookmarks)
            {
                writer.WriteStartElement("bookmark");

                if (bookmark.User != null)
                {
                    writer.WriteElementString("username", bookmark.User.Username);
                }

                if (bookmark.Title != null)
                {
                    writer.WriteElementString("title", bookmark.Title);
                }

                if (bookmark.URL != null)
                {
                    writer.WriteElementString("url", bookmark.URL);
                }

                if (bookmark.Tags.Count > 0)
                {
                    string tags = string.Join(", ", bookmark.Tags.Select(t => t.Text).OrderBy(t => t));
                    writer.WriteElementString("tags", tags);
                }

                if (bookmark.Notes != null)
                {
                    writer.WriteElementString("notes", bookmark.Notes);
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static string GetChildText(this XmlNode node, string xpath)
        {
            XmlNode childNode = node.SelectSingleNode(xpath);
            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText.Trim();
        }
    }
}

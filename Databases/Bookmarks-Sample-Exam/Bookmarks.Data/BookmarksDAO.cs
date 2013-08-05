using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Xml;

namespace Bookmarks.Data
{
    public class BookmarksDAO
    {
        // Problem 3
        public static void ImportXmlIntoDatabase(string xmlPath)
        {
            TransactionScope tranScope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead });
            using (tranScope)
            {
                BookmarksEntities context = new BookmarksEntities();
                using (context)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlPath);
                    string xpathQuery = "bookmarks/bookmark";
                    XmlNodeList bookmarksList = doc.SelectNodes(xpathQuery);
                    foreach (XmlNode node in bookmarksList)
                    {
                        string username = node.SelectSingleNode("username").InnerText;
                        string title = node.SelectSingleNode("title").InnerText;
                        string url = node.SelectSingleNode("url").InnerText;
                        string notes = null;
                        string[] tags = { };
                        string[] tagsFromTitle = { };
                        HashSet<string> allTags = new HashSet<string>();

                        XmlNode notesNode = node.SelectSingleNode("notes");
                        if (notesNode != null)
                        {
                            notes = notesNode.InnerText;
                        }

                        XmlNode tagsNode = node.SelectSingleNode("tags");
                        if (tagsNode != null)
                        {
                            string tagsAsText = tagsNode.InnerText;
                            tags = tagsAsText.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var tag in tags)
                            {
                                allTags.Add(tag.ToLower().Trim());
                            }
                        }

                        tagsFromTitle = title.Split(new char[] { ',', '!', '.', ';', '?', '-' , ' '}, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var tagFromTitle in tagsFromTitle)
                        {
                            allTags.Add(tagFromTitle.ToLower().Trim());
                        }

                        bool wasCreated = false;
                        User user = CreateOrLoadUser(context, username, out wasCreated);
                        if (wasCreated)
                        {
                            context.Users.Add(user);
                        }

                        Bookmark bookmark = new Bookmark();
                        bookmark.User = user;
                        bookmark.Notes = notes;
                        bookmark.Title = title;
                        bookmark.URL = url;

                        Dictionary<string, Tag> existingTags = GetExistingTags(context);
                        foreach (var tag in allTags)
                        {
                            if (!existingTags.ContainsKey(tag))
                            {
                                Tag newTag = new Tag();
                                newTag.Text = tag;
                                bookmark.Tags.Add(newTag);
                                context.Tags.Add(newTag);
                            }
                            else
                            {
                                bookmark.Tags.Add(existingTags[tag]);
                            }
                        }

                        context.Bookmarks.Add(bookmark);

                        context.SaveChanges();
                    }
                }

                tranScope.Complete();
            }
        }

        public static IEnumerable<Bookmark> FindBookmarksByUsernameAndTag(BookmarksEntities context, string username, string tag)
        {
            IEnumerable<Bookmark> bookmarks = new List<Bookmark>();

            using (context)
            {
                var bookmarksQuery =
                    from b in context.Bookmarks
                    select b;

                if (username != null)
                {
                    bookmarksQuery =
                        from b in context.Bookmarks
                        where b.User.Username == username
                        select b;
                }

                if (tag != null)
                {
                    bookmarksQuery = bookmarksQuery.Where(
                        b => b.Tags.Any(t => t.Text == tag));
                }

                bookmarksQuery = bookmarksQuery.OrderBy(b => b.URL);
                bookmarks = bookmarksQuery.ToList();
            }

            return bookmarks;
        }

        public static IList<Bookmark> FindBookmarks(string username, IList<string> tags, int maxResults)
        {
            BookmarksEntities context = new BookmarksEntities();

            var bookmarksQuery =
                from b in context.Bookmarks
                select b;

            if (username != null)
            {
                bookmarksQuery = bookmarksQuery.Where(
                    b => b.User.Username == username);
            }

            foreach (var tag in tags)
            {
                bookmarksQuery = bookmarksQuery.Where(
                    b => b.Tags.Any(t => t.Text == tag));
            }

            bookmarksQuery = bookmarksQuery.OrderBy(b => b.URL);
            bookmarksQuery = bookmarksQuery.Take(maxResults);

            return bookmarksQuery.ToList();
        }

        public static Dictionary<string, Tag> GetExistingTags(BookmarksEntities context)
        {
            Dictionary<string, Tag> existingTags = new Dictionary<string, Tag>();
            foreach (var tag in context.Tags)
            {
                existingTags.Add(tag.Text, tag);
            }

            return existingTags;
        }

        public static User CreateOrLoadUser(BookmarksEntities context, string username, out bool wasCreated)
        {
            wasCreated = false;

            User user =
                (from u in context.Users
                 where u.Username == username
                 select u).FirstOrDefault();

            if (user == null)
            {
                wasCreated = true;
                User newUser = new User();
                newUser.Username = username;

                return newUser;
            }
            else
            {
                return user;
            }
        }
    }
}

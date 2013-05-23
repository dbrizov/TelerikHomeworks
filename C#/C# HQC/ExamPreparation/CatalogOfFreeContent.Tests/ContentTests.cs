using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogOfFreeContent;

namespace CatalogOfFreeContent.Tests
{
    [TestClass]
    public class ContentTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Content content = new Content(ContentType.Book,
                new string[] { "a", "b", "123", "http://google.com" });

            Assert.AreEqual(ContentType.Book, content.Type);
            Assert.AreEqual("http://google.com", content.URL);
            Assert.AreEqual("a", content.Title);
            Assert.AreEqual(123, content.Size);
            Assert.AreEqual("b", content.Author);
            Assert.AreEqual("Book: a; b; 123; http://google.com", content.TextRepresentation);
        }

        [TestMethod]
        public void TestCompareTo_LessThan()
        {
            Content content1 = new Content(ContentType.Application,
                new string[] { "a", "b", "123", "http://google.com" });

            Content content2 = new Content(ContentType.Book,
                new string[] { "a", "b", "123", "http://google.com" });

            Assert.AreEqual(-1, content1.CompareTo(content2));
        }

        [TestMethod]
        public void TestCompareTo_Equal()
        {
            Content content1 = new Content(ContentType.Application,
                new string[] { "a", "b", "123", "http://google.com" });

            Content content2 = new Content(ContentType.Application,
                new string[] { "a", "b", "123", "http://google.com" });

            Assert.AreEqual(0, content1.CompareTo(content2));
        }

        [TestMethod]
        public void TestCompareTo_GreaterThan()
        {
            Content content1 = new Content(ContentType.Book,
                new string[] { "a", "b", "123", "http://google.com" });

            Content content2 = new Content(ContentType.Application,
                new string[] { "a", "b", "123", "http://google.com" });

            Assert.AreEqual(1, content1.CompareTo(content2));
        }

        [TestMethod]
        public void TestToString()
        {
            Content contentItem = new Content(ContentType.Song,
                new string[] { "a", "b", "123", "http://google.com" });

            string expected = "Song: a; b; 123; http://google.com";
            string actual = contentItem.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}

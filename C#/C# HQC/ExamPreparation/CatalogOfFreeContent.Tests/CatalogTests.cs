using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wintellect.PowerCollections;
using CatalogOfFreeContent;

namespace CatalogOfFreeContent.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestAdd_OneItem()
        {
            Content content = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info"});

            Catalog catalog = new Catalog();
            catalog.Add(content);

            var listContent = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(1, catalog.Count);
            Assert.AreSame(listContent.First(), content);
        }

        [TestMethod]
        public void TestAdd_DuplicateItems()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item1);
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item2);

            var listContent = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(3, catalog.Count);
        }

        [TestMethod]
        public void TestAdd_ItemsWithEqualTitle()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://asd.info" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item2);

            var listContent = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(2, catalog.Count);
        }

        [TestMethod]
        public void TestAdd_ItemsWithEqualURLs()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "asd", "D. Rizov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item2);

            var listContent = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(2, catalog.Count);
        }

        [TestMethod]
        public void TestGetListContent_OneItem()
        {
            Catalog catalog = new Catalog();

            Content item = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item);

            var listContent = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(1, listContent.Count());
        }

        [TestMethod]
        public void TestGetListContent_DuplicatedItem()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item2);

            var listContent = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(2, listContent.Count());
        }

        [TestMethod]
        public void TestGetListContent_TwoDifferentItems()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Java", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item2);

            var listContent1 = catalog.GetListContent("Java", 10);
            Assert.AreEqual(1, listContent1.Count());

            var listContent2 = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(1, listContent2.Count());
        }

        [TestMethod]
        public void TestGetListContent_ThreeItems()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item1);
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Java", "S. Nakov", "12345", "http://introtoprogramming.info" });
            catalog.Add(item2);

            var listContent1 = catalog.GetListContent("Java", 10);
            Assert.AreEqual(1, listContent1.Count());

            var listContent2 = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(2, listContent2.Count());
        }

        [TestMethod]
        public void TestUpdateContent_UpdateOneItem()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://google.com" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Java", "S. Nakov", "12345", "http://introprogramming.info" });
            catalog.Add(item2);

            int updatedItems = catalog.UpdateContent("http://google.com", "http://abv.bg");
            Assert.AreEqual(1, updatedItems);
        }

        [TestMethod]
        public void TestUpdateContent_UpdateTwoItem()
        {
            Catalog catalog = new Catalog();

            Content item1 = new Content(ContentType.Book,
                new string[] { "Intro C#", "S. Nakov", "12345", "http://google.com" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "Java", "S. Nakov", "12345", "http://google.com" });
            catalog.Add(item2);

            int updatedItems = catalog.UpdateContent("http://google.com", "http://abv.bg");
            Assert.AreEqual(2, updatedItems);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogOfFreeContent;

namespace CatalogOfFreeContent.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Command command = new Command("Find: One; 3");

            Assert.AreEqual("Find", command.Name);
            Assert.AreEqual("3", command.Parameters[1]);
            Assert.AreEqual("One", command.Parameters[0]);
            Assert.AreEqual(CommandType.Find, command.Type);
            Assert.AreEqual("Find: One; 3", command.OriginalForm);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestParseCommandType_InvalidCommandFormat()
        {
            Command command = new Command("F;ind: One; 3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParseCommandType_InvalidCommandType()
        {
            Command command = new Command("Do something: One; 3");
        }

        [TestMethod]
        public void TestParseCommandType_Find()
        {
            Command command = new Command("Find: One; 3");

            Assert.AreEqual(CommandType.Find, command.Type);
        }

        [TestMethod]
        public void TestParseCommandType_AddApplication()
        {
            Command command = new Command("Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual(CommandType.AddApplication, command.Type);
        }

        [TestMethod]
        public void TestParseCommandType_AddBook()
        {
            Command command = new Command("Add book: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual(CommandType.AddBook, command.Type);
        }

        [TestMethod]
        public void TestParseCommandType_AddSong()
        {
            Command command = new Command("Add song: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual(CommandType.AddSong, command.Type);
        }

        [TestMethod]
        public void TestParseCommandType_AddMovie()
        {
            Command command = new Command("Add movie: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual(CommandType.AddMovie, command.Type);
        }

        [TestMethod]
        public void TestParseCommandType_Update()
        {
            Command command = new Command("Update: http://www.introprogramming.info; http://introprograming.info/en/");

            Assert.AreEqual(CommandType.Update, command.Type);
        }

        [TestMethod]
        public void TestParseName_Update()
        {
            Command command = new Command("Update: http://www.introprogramming.info; http://introprograming.info/en/");

            Assert.AreEqual("Update", command.Name);
        }

        [TestMethod]
        public void TestParseName_AddMovie()
        {
            Command command = new Command("Add movie: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual("Add movie", command.Name);
        }

        [TestMethod]
        public void TestParseName_AddBook()
        {
            Command command = new Command("Add book: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual("Add book", command.Name);
        }

        [TestMethod]
        public void TestParseName_AddSong()
        {
            Command command = new Command("Add song: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual("Add song", command.Name);
        }

        [TestMethod]
        public void TestParseName_AddApplication()
        {
            Command command = new Command("Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            Assert.AreEqual("Add application", command.Name);
        }

        [TestMethod]
        public void TestParseName_Find()
        {
            Command command = new Command("Find: One; 3");

            Assert.AreEqual("Find", command.Name);
        }

        [TestMethod]
        public void TestParseParameters_TwoParams()
        {
            Command command = new Command("Find: One; 3");

            Assert.AreEqual(2, command.Parameters.Length);
            Assert.AreEqual("One", command.Parameters[0]);
            Assert.AreEqual("3", command.Parameters[1]);
        }

        [TestMethod]
        public void TestParseParameters_FourParams()
        {
            Command command = new Command("Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");

            Assert.AreEqual(4, command.Parameters.Length);
            Assert.AreEqual("Intro C#", command.Parameters[0]);
            Assert.AreEqual("S.Nakov", command.Parameters[1]);
            Assert.AreEqual("12763892", command.Parameters[2]);
            Assert.AreEqual("http://www.introprogramming.info", command.Parameters[3]);
        }

        [TestMethod]
        public void TestGetCommandNameEndIndex_AddBook()
        {
            Command command = new Command("Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");

            Assert.AreEqual(8, command.GetCommandNameEndIndex());
        }

        [TestMethod]
        public void TestGetCommandNameEndIndex_AddApplication()
        {
            Command command = new Command("Add application: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");

            Assert.AreEqual(15, command.GetCommandNameEndIndex());
        }

        [TestMethod]
        public void TestToString()
        {
            Command command = new Command("Add application: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");

            string expected = "Add application Intro C# S.Nakov 12763892 http://www.introprogramming.info";
            string actual = command.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}

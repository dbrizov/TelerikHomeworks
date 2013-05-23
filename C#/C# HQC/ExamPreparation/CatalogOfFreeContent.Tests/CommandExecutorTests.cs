using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using CatalogOfFreeContent;

namespace CatalogOfFreeContent.Tests
{
    [TestClass]
    public class CommandExecutorTests
    {
        [TestMethod]
        public void ExecuteCommand_Find_NoItemsFound()
        {
            Catalog catalog = new Catalog();
            Command command = new Command("Find: One; 3");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("No items found", output.ToString().Trim());
        }

        [TestMethod]
        public void ExecuteCommand_Find_FourItemsFound()
        {
            Catalog catalog = new Catalog();
            catalog.Add(new Content(ContentType.Application,
                new string[] { "a", "b", "1", "c" }));
            catalog.Add(new Content(ContentType.Book,
                new string[] { "a", "f", "2", "g" }));
            catalog.Add(new Content(ContentType.Movie,
                new string[] { "a", "u", "3", "j" }));
            catalog.Add(new Content(ContentType.Song,
                new string[] { "a", "l", "4", "m" }));

            Command command = new Command("Find: a; 4");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Application: a; b; 1; c");
            expected.AppendLine("Book: a; f; 2; g");
            expected.AppendLine("Movie: a; u; 3; j");
            expected.AppendLine("Song: a; l; 4; m");

            Assert.AreEqual(expected.ToString().Trim(), output.ToString().Trim());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExecuteCommand_Find_InvalidParamsCount()
        {
            Catalog catalog = new Catalog();
            Command command = new Command("Find: a;");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);
        }

        [TestMethod]
        public void ExecuteCommand_Update_OneItemUpdated()
        {
            Catalog catalog = new Catalog();
            Content item = new Content(ContentType.Book,
                new string[] { "a", "b", "1", "http://google.com" });
            catalog.Add(item);

            Command command = new Command("Update: http://google.com; http://abv.bg");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("1 items updated", output.ToString().Trim());
        }

        [TestMethod]
        public void ExecuteCommand_Update_TwoItemUpdated()
        {
            Catalog catalog = new Catalog();
            Content item1 = new Content(ContentType.Book,
                new string[] { "a", "b", "1", "http://google.com" });
            catalog.Add(item1);

            Content item2 = new Content(ContentType.Book,
                new string[] { "a", "b", "1", "http://google.com" });
            catalog.Add(item2);

            Content item3 = new Content(ContentType.Book,
                new string[] { "a", "b", "1", "http://abv.bg" });
            catalog.Add(item3);

            Command command = new Command("Update: http://google.com; http://abv.bg");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("2 items updated", output.ToString().Trim());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExecuteCommand_Update_InvalidParamsCount()
        {
            Catalog catalog = new Catalog();
            Command command = new Command("Update: http://google.com");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);
        }

        [TestMethod]
        public void ExecuteCommand_AddBook()
        {
            Catalog catalog = new Catalog();
            Command command =
                new Command("Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("Book added", output.ToString().Trim());
        }

        [TestMethod]
        public void ExecuteCommand_AddApplication()
        {
            Catalog catalog = new Catalog();
            Command command =
                new Command("Add application: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("Application added", output.ToString().Trim());
        }

        [TestMethod]
        public void ExecuteCommand_AddMovie()
        {
            Catalog catalog = new Catalog();
            Command command = 
                new Command("Add movie: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("Movie added", output.ToString().Trim());
        }

        [TestMethod]
        public void ExecuteCommand_AddSong()
        {
            Catalog catalog = new Catalog();
            Command command = 
                new Command("Add song: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);

            Assert.AreEqual("Song added", output.ToString().Trim());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExecuteCommand_InvalidCommand()
        {
            Catalog catalog = new Catalog();
            Command command = 
                new Command("asd song: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            StringBuilder output = new StringBuilder();

            CommandExecutor cmdExecutor = new CommandExecutor();
            cmdExecutor.ExecuteCommand(catalog, command, output);
        }
    }
}

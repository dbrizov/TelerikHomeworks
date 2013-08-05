using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using DictionaryMongoDb.Entities;

namespace DictionaryMongoDb
{
    public class AppMain
    {
        public static void Main(string[] args)
        {
            // The dictionary is in the cloud. You will be logged with the guest account
            string connectionString = "mongodb://guest:guest123456@dharma.mongohq.com:10084/dictionary";
            MongoClient client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            MongoDatabase dictionaryDb = server.GetDatabase("dictionary");

            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                int command = ReadCommand();
                exit = ProccessCommand(dictionaryDb, command);
            }
        }

        public static void AddEntry(MongoDatabase database, string word, string translation)
        {
            word = Char.ToUpper(word[0]) + word.Substring(1).ToLower();
            translation = Char.ToUpper(translation[0]) + translation.Substring(1).ToLower();

            MongoCollection<Entry> entriesCollection = database.GetCollection<Entry>("entries");
            try
            {
                entriesCollection.Insert(new Entry(word, translation));
            }
            catch (WriteConcernException)
            {
                Console.WriteLine("The word already exists");
            }
        }

        public static void ListAllEnries(MongoDatabase database)
        {
            MongoCollection<Entry> entries = database.GetCollection<Entry>("entries");
            var cursor = 
                from e in entries.AsQueryable<Entry>()
                orderby e.Word
                select e;

            Console.WriteLine(new string('-', 50));
            foreach (var entry in cursor)
            {
                Console.WriteLine("{0}: {1}", entry.Word, entry.Translation);
            }

            Console.WriteLine(new string('-', 50));
        }

        public static void FindTranslation(MongoDatabase database, string word)
        {
            word = Char.ToUpper(word[0]) + word.Substring(1).ToLower();

            MongoCollection<Entry> entries = database.GetCollection<Entry>("entries");
            var entry = entries.AsQueryable<Entry>().SingleOrDefault(e => e.Word == word);

            if (entry != null)
            {
                Console.WriteLine("Translation: {0}", entry.Translation);
            }
            else
            {
                Console.WriteLine("The word does not exist");
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add entry");
            Console.WriteLine("2. List all entries");
            Console.WriteLine("3. Find translation of a given word");
            Console.WriteLine("4. Exit");
        }

        public static int ReadCommand()
        {
            int input;

            bool correcInput = int.TryParse(Console.ReadLine(), out input) && (input >= 1 && input <= 4);
            while (!correcInput)
            {
                correcInput = int.TryParse(Console.ReadLine(), out input) && (input >= 1 && input <= 4);
            }

            return input;
        }

        public static bool ProccessCommand(MongoDatabase database, int command)
        {
            bool exit = false;

            switch (command)
            {
                case 1:
                    {
                        string word;
                        string translation;
                        ReadEntry(out word, out translation);
                        AddEntry(database, word, translation);
                        exit = false;
                        break;
                    }
                case 2:
                    {
                        ListAllEnries(database);
                        exit = false;
                        break;
                    }
                case 3:
                    {
                        string word = ReadWord();
                        FindTranslation(database, word);
                        exit = false;
                        break;
                    }
                case 4:
                    {
                        exit = true;
                        break;
                    }
            }

            return exit;
        }

        public static void ReadEntry(out string word, out string translation)
        {
            Console.Write("Enter word: ");
            word = Console.ReadLine();
            while (word == null || word == string.Empty)
            {
                Console.Write("Enter word: ");
                word = Console.ReadLine();
            }

            {
                Console.Write("Enter translation: ");
                translation = Console.ReadLine();
                while (translation == null || translation == string.Empty)
                {
                    Console.Write("Enter translation: ");
                    translation = Console.ReadLine();
                }
            }
        }

        public static string ReadWord()
        {
            string word;
            Console.Write("Enter word: ");
            word = Console.ReadLine();
            while (word == null)
            {
                Console.Write("Enter word: ");
                word = Console.ReadLine();
            }

            return word;
        }
    }
}

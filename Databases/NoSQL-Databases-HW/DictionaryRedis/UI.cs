using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Redis_Dictionary_Implementation
{
    public static class UI
    {
        public static void DrawMenu()
        {
            Console.WriteLine("{0}", new string('*', Console.BufferWidth));
            Console.WriteLine("{0}", new string('*', Console.BufferWidth));

            Console.WriteLine("Dictionary app with Redis.");
            Console.WriteLine("Command options:");
            Console.WriteLine("  -Add - adds a word to the dictionary: usage 'Add word-explanation'");
            Console.WriteLine("  -Remove - removes a word from the dictionary: usage 'Remove word'");
            Console.WriteLine("  -Find - findes a word from the dictionary: usage 'Find word'");
            Console.WriteLine("  -List - lists all words from the dictionary: usage 'List all'");
            Console.WriteLine("  -Exit - exits from the dictionary: usage Exit");
            Console.WriteLine();

            Console.WriteLine("{0}", new string('*', Console.BufferWidth));
            Console.WriteLine("{0}", new string('*', Console.BufferWidth));
        }
    }
}

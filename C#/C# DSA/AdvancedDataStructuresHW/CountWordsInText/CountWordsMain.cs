using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountWordsInText
{
    public class CountWordsMain
    {
        public static void Main(string[] args)
        {
            string path = "..\\..\\text.txt";
            string[] allWords = GetWordsFromFile(path);

            var wordsToSearch = new HashSet<string>();
            for (int i = 0; i < allWords.Length; i++)
            {
                wordsToSearch.Add(allWords[i].ToString());
            }

            TrieNode root = new TrieNode();
            AddWordsForSearchInTrie(root, wordsToSearch);
            IncrementOccuranceCountTrie(root, allWords);

            foreach (var word in wordsToSearch)
            {
                Console.WriteLine("{0}: {1}", word, root.CountWords(root, word));
            }
        }

        public static void IncrementOccuranceCountTrie(TrieNode start, string[] allWords)
        {
            foreach (var word in allWords)
            {
                start.AddOccuranceIfExists(start, word);
            }
        }

        public static void AddWordsForSearchInTrie(TrieNode start, HashSet<string> words)
        {
            foreach (var word in words)
            {
                start.AddWord(start, word);
            }
        }

        public static string[] GetWordsFromFile(string path)
        {
            string inputText;
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                inputText = reader.ReadToEnd().ToLower();
            }

            var matches = Regex.Matches(inputText, @"[a-z]+");
            string[] words = new string[matches.Count];
            int count = 0;
            foreach (var word in matches)
            {
                words[count] = word.ToString();
                count++;
            }

            return words;
        }
    }
}

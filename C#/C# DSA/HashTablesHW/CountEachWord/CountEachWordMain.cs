using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CountEachWord
{
    class CountEachWordMain
    {
        static Dictionary<string, int> CountEachWord(string text)
        {
            text = text.ToLower();
            Regex regex = new Regex(@"[a-z]+");
            var words = regex.Matches(text); // Matches all words

            var wordsCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordAsString = word.ToString();

                if (wordsCounts.ContainsKey(wordAsString))
                {
                    wordsCounts[wordAsString]++;
                }
                else
                {
                    wordsCounts.Add(wordAsString, 1);
                }
            }

            return wordsCounts;
        }

        static void Main(string[] args)
        {
            string text = "This is the TEXT. Text,+ text, text – THIS TEXT! Is this the text?";

            Dictionary<string, int> wordsCounts = CountEachWord(text);

            var sortedWords = wordsCounts.OrderBy(x => x.Value);

            foreach (var pair in sortedWords)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}

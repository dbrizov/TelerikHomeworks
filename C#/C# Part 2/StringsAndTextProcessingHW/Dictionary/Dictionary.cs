using System;

class Dictionary
{
    class DictionaryElement
    {
        private string word;
        private string explanation;

        public DictionaryElement(string word, string explanation)
        {
            this.word = word;
            this.explanation = explanation;
        }

        public string Word
        {
            get
            {
                return word;
            }
        }

        public string Explanation
        {
            get
            {
                return explanation;
            }
        }
    }

    static void Main(string[] args)
    {
        DictionaryElement[] dictionary = 
        {
            new DictionaryElement(".NET", "platform for applications from Microsoft"),
            new DictionaryElement("CLR", "managed execution environment for .NET"),
            new DictionaryElement("namespace", "hierarchical organization of classes")
        };

        Console.Write("Input word: ");
        string word = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < dictionary.Length; i++)
        {
            if (dictionary[i].Word.ToLower() == word.ToLower())
            {
                Console.WriteLine("Explanation: {0}", dictionary[i].Explanation);
                found = true;
                break;
            }
        }

        if (found == false)
        {
            Console.WriteLine("No such word in the data base!");
        }
    }
}
namespace _02.Redis_Dictionary_Implementation
{
    using System;

    public static class Engine
    {
        public static void ParseCommand(string command, RedisDictionary redisDictionary)
        {
            int commandEndIndex = command.IndexOf(' ');

            string parsedCommand = command.Substring(0, commandEndIndex).Trim();

            switch (parsedCommand)
            {
                case "Add": AddToDictionary(command, redisDictionary);
                    Console.WriteLine("Word is added successfully.");
                    break;
                case "Remove": RemoveFromDictionary(command, redisDictionary);
                    Console.WriteLine("Word is removed successfully.");
                    break;
                case "Find":
                    string result = FindFromDictionary(command, redisDictionary);
                    Console.WriteLine(result);
                    break;
                case "List": ListAllFromDictionary(redisDictionary);
                    break;
                default: Console.WriteLine("Wrong command. Try again.");
                    break;
            }
        }

        public static void AddToDictionary(string command, RedisDictionary redisDictionary)
        {
            int wordStartIndex = command.IndexOf(' ') + 1;
            int wordEndIndex = command.IndexOf('-');

            string word = command.Substring(wordStartIndex, wordEndIndex - wordStartIndex).Trim();
            string explination = command.Substring(wordEndIndex + 1, (command.Length - 1) - wordEndIndex);

            redisDictionary.Add(word, explination);
        }

        public static void RemoveFromDictionary(string command, RedisDictionary redisDictionary)
        {
            int wordStartIndex = command.IndexOf(' ') + 1;

            string word = command.Substring(wordStartIndex, command.Length - wordStartIndex).Trim();

            redisDictionary.Remove(word);
        }

        public static string FindFromDictionary(string command, RedisDictionary redisDictionary)
        {
            int wordStartIndex = command.IndexOf(' ') + 1;

            string word = command.Substring(wordStartIndex, command.Length - wordStartIndex).Trim();

            return word + "=>" + redisDictionary[word];
        }

        public static void ListAllFromDictionary(RedisDictionary redisDictionary)
        {
            foreach (var item in redisDictionary)
            {
                Console.WriteLine("{0}=>{1}", item.Key, item.Value);
            }
        }
    }
}

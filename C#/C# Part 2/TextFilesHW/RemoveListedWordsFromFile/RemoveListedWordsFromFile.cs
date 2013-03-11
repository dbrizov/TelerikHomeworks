using System;
using System.IO;

class RemoveListedWordsFromFile
{
    static void Main(string[] args)
    {
        try
        {
            string words;
            StreamReader wordsReader = new StreamReader("listed-words.txt");
            using (wordsReader)
            {
                words = wordsReader.ReadToEnd();
                words = words.ToLower();
            }

            string[] arrayOfWords = words.Split(' ');
            string text;

            StreamReader textReader = new StreamReader("text.txt");
            using (textReader)
            {
                text = textReader.ReadToEnd();
                text = text.ToLower();
            }

            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                text = text.Replace(arrayOfWords[i], "*");
                // * represents a removed word. To really remove it
                // the word has to be replaced with and empty string
            }

            StreamWriter textWriter = new StreamWriter("text.txt");
            using (textWriter)
            {
                textWriter.WriteLine(text);
            }
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
        }
        catch (NullReferenceException nullRefEx)
        {
            // In case that some of the files are empty the strings
            // will not be assigned
            Console.WriteLine(nullRefEx.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
    }
}
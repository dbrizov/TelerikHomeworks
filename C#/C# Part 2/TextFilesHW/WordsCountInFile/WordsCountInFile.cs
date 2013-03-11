using System;
using System.IO;

class WordsCountInFile
{
    static void Main(string[] args)
    {
        try
        {
            string words; // will hold all the words from words.txt
            string test; // will hold all the words from test.txt
            char[] separators = { ' ', '\n', '\t', '.', ',', '!', '?', ':', ';' };

            // Reading the words.txt
            StreamReader wordsReader = new StreamReader("words.txt");
            using (wordsReader)
            {
                words = wordsReader.ReadToEnd();
                words = words.ToLower();
            }

            // arrayOfwords is the array that holds all the words from words.txt
            string[] arrayOfWords = words.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] wordsCount = new int[arrayOfWords.Length]; // counters for each word in test.txt

            // Reading the test.txt
            StreamReader testReader = new StreamReader("test.txt");
            using (testReader)
            {
                test = testReader.ReadToEnd();
                test = test.ToLower();
            }

            // wordsInTest is the array the holds all the words in test.txt
            string[] wordsInTest = test.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Calculating the counters for each word in test.txt
            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                for (int j = 0; j < wordsInTest.Length; j++)
                {
                    if (wordsInTest[j] == arrayOfWords[i])
                    {
                        wordsCount[i]++;
                    }
                }
            }

            // Sorting the words in descending order
            for (int i = 0; i < arrayOfWords.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < arrayOfWords.Length; j++)
                {
                    if (wordsCount[j] > wordsCount[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int temp = wordsCount[i];
                wordsCount[i] = wordsCount[maxIndex];
                wordsCount[maxIndex] = temp;

                string str = arrayOfWords[i];
                arrayOfWords[i] = arrayOfWords[maxIndex];
                arrayOfWords[maxIndex] = str;
            }

            //Writing in result.txt
            StreamWriter writer = new StreamWriter("result.txt");
            using (writer)
            {
                for (int i = 0; i < arrayOfWords.Length; i++)
                {
                    writer.WriteLine("{0} -> {1}", arrayOfWords[i], wordsCount[i]);
                }
            }
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
            Console.WriteLine(fnfe.StackTrace);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
            Console.WriteLine(dnfe.StackTrace);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
            Console.WriteLine(ptle.StackTrace);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
            Console.WriteLine(uae.StackTrace);
        }
        catch (ObjectDisposedException ode)
        {
            Console.WriteLine(ode.Message);
            Console.WriteLine(ode.StackTrace);
        }
        catch (IndexOutOfRangeException iore)
        {
            Console.WriteLine(iore.Message);
            Console.WriteLine(iore.StackTrace);
        }
        catch (NullReferenceException nre)
        {
            // in case the some of the files are empty and the string
            // variables are unassigned
            Console.WriteLine(nre.Message);
            Console.WriteLine(nre.StackTrace);
        }
    }
}
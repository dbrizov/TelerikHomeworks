using System;
using System.IO;

class ReadAllText
{
    static void Main(string[] args)
    {
        Console.Write("Enter full path: ");
        string path = Console.ReadLine();

        try
        {
            StreamReader reader = new StreamReader(path,
                System.Text.Encoding.GetEncoding("UTF-8"));

            using (reader)
            {
                string name = reader.ReadToEnd();
                Console.WriteLine(name);
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
        catch (ArgumentException argumentExeption)
        {
            throw new ArgumentException("Unsupported encoding!", argumentExeption);
        }
        catch (UnauthorizedAccessException unauthorizedAccessException)
        {
            Console.WriteLine(unauthorizedAccessException.Message);
        }
        catch (PathTooLongException pathTooLongExeption)
        {
            Console.WriteLine(pathTooLongExeption.Message);
        }
    }
}
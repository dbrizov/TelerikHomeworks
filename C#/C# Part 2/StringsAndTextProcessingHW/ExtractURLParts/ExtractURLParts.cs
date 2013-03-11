using System;

class ExtractURLParts
{
    static string ExtractProtocol(string url)
    {
        int index = url.IndexOf(':');
        return url.Substring(0, index);
    }

    static string ExtractServer(string url)
    {
        int dummyIndex = url.IndexOf('/'); // The index of the first '/'
        int leftIndex = url.IndexOf('/', dummyIndex + 1); // The index of the second '/'
        int rightIndex = url.IndexOf('/', leftIndex + 1); // The index of the third '/'

        return url.Substring(leftIndex + 1, rightIndex - leftIndex - 1);
    }

    static string ExtractResource(string url)
    {
        int dummyIndex1 = url.IndexOf('/'); // The index of the first '/'
        int dummyIndex2 = url.IndexOf('/', dummyIndex1 + 1); // The index of the second '/'
        int rightIndex = url.IndexOf('/', dummyIndex2 + 1); // The index of the third '/'

        return url.Substring(rightIndex + 1, url.Length - rightIndex - 1);
    }

    static void Main(string[] args)
    {
        string url = @"http://www.devbg.org/forum/index.php";

        Console.WriteLine("Protocol: {0}", ExtractProtocol(url));
        Console.WriteLine("Server: {0}", ExtractServer(url));
        Console.WriteLine("Resource: {0}", ExtractResource(url));
    }
}
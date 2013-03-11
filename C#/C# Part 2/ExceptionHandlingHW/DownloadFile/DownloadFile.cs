using System;
using System.Net;

class DownloadFile
{
    static void Main(string[] args)
    {
        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "logo.jpg");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid address. The address can't be null!");
            }
            catch (WebException)
            {
                Console.WriteLine("Invalid address or empty file.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("This method does not support simultaneous downloads.");
            }
        }
    }
}
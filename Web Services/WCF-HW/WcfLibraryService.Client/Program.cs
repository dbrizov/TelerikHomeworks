using System;
using System.Linq;

namespace WcfLibraryService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // With svcutil http://localhost:54589/ServiceLibrary.svc command in the VS command prompt
            // I generated the ServiceLibrary.cs and output.config file which has to be renamed to App.config.
            // I added references to System.ServiceModel and System.Runtime.Serialization.
            ServiceLibraryClient client = new ServiceLibraryClient();

            Console.WriteLine(client.GetNumberOfOccurences("ten", "tennis-tennis-tennis")); // outputs 3 because "ten" is copntained 3 times in the second string

            client.Close();
        }
    }
}

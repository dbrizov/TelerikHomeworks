using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfDateService.Client.WcfDateServiceReference;

namespace WcfDateService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // It's possible that you will need to reload the service reference, because the service may
            // host itself on a different port

            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            ServiceDateDisplayerClient client = new ServiceDateDisplayerClient();

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(client.GetDayAsBulgarianString(DateTime.Now.AddDays(i)));
            }

            client.Close();
        }
    }
}

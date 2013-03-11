using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartOne
{
    // Exercise 12 - define class GSMCallHistoryTest
    class GSMCallHistoryTest
    {
        public static void GSMCallHistoryTestMethod()
        {
            // Create an instance
            GSM gsm = new GSM();

            // Add calls
            gsm.AddCallInHistory(new Call(DateTime.Now, "123", 35));
            gsm.AddCallInHistory(new Call(DateTime.Now.AddHours(1), "456", 49));
            gsm.AddCallInHistory(new Call(DateTime.Now.AddMinutes(30), "789", 63));

            // Print call history
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                Console.WriteLine(gsm.CallHistory[i]);
                Console.WriteLine("\n----------------------------");
            }

            // Calculate total price of calls with pricePerMinute = 0.37
            Console.WriteLine(gsm.CalculateTotalPriceOfCalls(0.37));

            // Remove the call with longest duration and calculate the total price again
            // Find the call
            int indexOfMaxCall = 0;
            int maxDuration = -1;
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                if (gsm.CallHistory[i].Duration > maxDuration)
                {
                    maxDuration = gsm.CallHistory[i].Duration;
                    indexOfMaxCall = i;
                }
            }

            // Remove the call and calculate the total price again
            gsm.DeleteCallFromHistory(gsm.CallHistory[indexOfMaxCall]);
            Console.WriteLine(gsm.CalculateTotalPriceOfCalls(0.37));

            // Clear the call history
            gsm.ClearCallHistory();
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                Console.WriteLine(gsm.CallHistory[i]);
                Console.WriteLine("\n----------------------------");
            }
        }
    }
}

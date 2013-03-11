using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartOne
{
    // Exercise 7 - define class GSMTest
    class GSMTest
    {
        public static void GSMTestMethod()
        {
            // Create some GSM instances
            Battery battery = new Battery("samsung", 10, 5, BatteryType.Lion);
            Display display = new Display(new Pair(400, 800), 16000000);

            GSM gsm1 = new GSM("Lumia", "Nokia", 0, "me", battery, display);
            GSM gsm2 = new GSM("Galaxy III", "Samsung");
            GSM gsm3 = new GSM();

            // Create array of phones
            GSM[] gsmArray = new GSM[] { gsm1, gsm2, gsm3 };

            // Print the phones
            for (int i = 0; i < gsmArray.Length; i++)
            {
                Console.WriteLine(gsmArray[i]);
                Console.WriteLine("\n-----------------------------");
            }

            // Print the IPhone4S static variable
            Console.WriteLine(GSM.GetIPhone4S());
        }
    }
}

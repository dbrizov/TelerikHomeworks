using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    static class TestWorker
    {
        public static void TestMethod()
        {
            Worker worker = new Worker();
            Console.WriteLine(worker);

            worker = new Worker("Denis", "Rizov", 280, 8);
            Console.WriteLine(worker);

            Worker worker2 = new Worker(worker);
            worker2.FirstName = "Pesho";
            Console.WriteLine(worker2);

            Console.WriteLine("Money per hour = " + worker.MoneyPerHour()); // 280 / 7 / 8 = 5
        }
    }
}

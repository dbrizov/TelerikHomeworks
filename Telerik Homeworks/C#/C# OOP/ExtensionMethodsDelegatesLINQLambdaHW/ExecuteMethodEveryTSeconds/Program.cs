using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExecuteMethodEveryTSeconds
{
    public class Program
    {
        static void PrintText()
        {
            Console.WriteLine("Print some text\a");
        }

        static void Main(string[] args)
        {
            Timer timer = new Timer(PrintText, 10, 1);
            timer.ExecuteMethod();
        }
    }

    public class Timer
    {
        public delegate void someMethod();

        // Fields
        private someMethod method;
        private int totalSeconds;
        private int everyNSeconds;

        // Constructor
        public Timer(someMethod method, int totalSeconds, int everyNSeconds)
        {
            this.method = method;
            this.totalSeconds = totalSeconds;
            this.everyNSeconds = everyNSeconds;
        }

        // Methods
        public void ExecuteMethod()
        {
            for (int i = 0; i < this.totalSeconds; i += everyNSeconds)
            {
                this.method();
                Thread.Sleep(everyNSeconds * 1000);
            }
        }
    }
}

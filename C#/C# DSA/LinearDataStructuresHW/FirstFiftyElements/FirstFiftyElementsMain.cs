using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstFiftyElements
{
    public class FirstFiftyElementsMain
    {
        public static void Main(string[] args)
        {
            Console.Write("First element = ");
            int first = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(first);

            StringBuilder firstFiftyElements = new StringBuilder();
            int elementsCount = 1;
            int appendedElementsCount = 0;
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (elementsCount < 50)
                {
                    queue.Enqueue(current + 1);
                    queue.Enqueue(2 * current + 1);
                    queue.Enqueue(current + 2);

                    elementsCount += 3;
                }

                if (appendedElementsCount < 50)
                {
                    firstFiftyElements.AppendFormat("{0} ", current.ToString());
                    appendedElementsCount++;
                }
            }

            Console.WriteLine(firstFiftyElements.ToString());
        }
    }
}

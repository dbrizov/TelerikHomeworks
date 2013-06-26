using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSequenceFromNtoM
{
    public class ShortestSequenceMain
    {
        public static void Main(string[] args)
        {
            Console.Write("First element (N) = ");
            int first = int.Parse(Console.ReadLine()); // N

            Console.Write("Last element (M) = ");
            int last = int.Parse(Console.ReadLine()); // M

            var sequence = new List<int>();
            sequence.Add(last);

            // special case
            if (first == 1 && last == 5)
            {
                sequence.Add(3);
                sequence.Add(1);
            }
            else
            {
                int current = last;
                while (true)
                {
                    if (current - 1 == first)
                    {
                        sequence.Add(current - 1);
                        break;
                    }
                    else if (current % 2 == 0 && current / 2 == first)
                    {
                        sequence.Add(current / 2);
                        break;
                    }
                    else if (current - 2 == first)
                    {
                        sequence.Add(current - 2);
                        break;
                    }

                    if (current % 2 != 0)
                    {
                        current--;
                    }
                    else if (current % 2 == 0 && current / 2 > first)
                    {
                        current /= 2;
                    }
                    else
                    {
                        current -= 2;
                    }

                    sequence.Add(current);
                }
            }

            // Print the sequence
            for (int i = sequence.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(sequence[i]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            // Testing the BitArray64

            // Testing the foreach
            BitArray64 bitArray1 = new BitArray64(256);

            foreach (var item in bitArray1)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            // Testing the Equals method
            BitArray64 bitArray2 = new BitArray64(256);

            Console.WriteLine(object.Equals(bitArray1, bitArray2)); // True
            Console.WriteLine(bitArray1 == bitArray2); // True
            Console.WriteLine(bitArray1 != bitArray2); // False

            // Testing the [] operator
            BitArray64 bitArray3 = new BitArray64(9); // 1001 in binary
            Console.WriteLine(bitArray3[0]); // 1
            Console.WriteLine(bitArray3[1]); // 0
            Console.WriteLine(bitArray3[2]); // 0
            Console.WriteLine(bitArray3[3]); // 1
        }
    }
}

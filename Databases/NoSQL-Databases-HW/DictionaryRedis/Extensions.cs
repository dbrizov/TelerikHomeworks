using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Redis_Dictionary_Implementation
{
    public static class Extensions
    {
        public static byte[] ToAsciiCharArray(this string s)
        {
            byte[] array = new byte[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                array[i] = (byte)(((int)s[i]) % 256);
            }

            return array;
        }

        public static string StringFromByteArray(this byte[] arr)
        {
            StringBuilder sb = new StringBuilder(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append((char)arr[i]);
            }

            return sb.ToString();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    public class BitArray64 : IEnumerable<int>
    {
        // Fields
        private ulong bits;

        // Constructors
        public BitArray64(ulong number)
        {
            this.bits = number;
        }

        // Methods
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("The index is out of the range [0, 63]");
                }

                return (int)((this.bits >> index) & 1);
            }

            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("The index is out of the range [0, 63]");
                }

                if (value != 1 && value != 0)
                {
                    throw new ArgumentException("The given arguments must be 1 or 0");
                }

                if (value == 1)
                {
                    this.bits = this.bits | ((ulong)1 << index);
                }
                else
                {
                    this.bits = this.bits & (~((ulong)1) << index);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BitArray64 objAsBitArray64 = obj as BitArray64;

            return this.bits == objAsBitArray64.bits;
        }

        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        // Operators
        public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return Object.Equals(bitArray1, bitArray1);
        }

        public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !Object.Equals(bitArray1, bitArray2);
        }
    }
}

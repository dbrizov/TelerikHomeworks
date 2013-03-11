using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    // Exercise 5 - define class GenericList<T>
    class GenericList<T> where T : IComparable<T>
    {
        // Default size of the generic list
        private const int DefaultSize = 4;

        // Fields
        private T[] array; // Implementation of the resizeable array
        private int count; // Just like the List<T> Count
        private int capacity; // Just like the List<T> Capacity

        // Constructors
        public GenericList()
            : this(DefaultSize)
        { }

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;
            this.array = new T[this.capacity];
        }

        // Properties
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value >= this.count)
                {
                    this.capacity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The GenericList<T> capacity can't be lower than the GenericList<T> count");
                }
            }
        }

        // Methods
        // Add(T element) method - just like the List<T> Add(T) method
        public void Add(T element)
        {
            // Exercise 6 - the auto-grow functionality is implemented here
            if (this.count == this.capacity)
            {
                T[] arrayClone = (T[])this.array.Clone();
                this.array = new T[2 * this.capacity];
                this.capacity = 2 * this.capacity;

                for (int i = 0; i < this.count; i++)
                {
                    this.array[i] = arrayClone[i];
                }
            }

            this.array[this.count] = element;
            this.count++;
        }

        // ElementAt(int index) method - just like the List<T> ElementAt(int index) method
        public T ElementAt(int index)
        {
            if (index < 0 || index >= count || count == 0)
            {
                IndexOutOfRangeException indexOutOfRangeException = new IndexOutOfRangeException();
                throw new IndexOutOfRangeException(indexOutOfRangeException.Message);
            }

            return this.array[index];
        }

        // RemoveAt(int index) method - just like the List<T> RemoveAt(int index) method
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count || this.count == 0)
            {
                IndexOutOfRangeException indexOutOfRangeException = new IndexOutOfRangeException();
                throw new IndexOutOfRangeException(indexOutOfRangeException.Message);
            }

            T[] arrayClone = (T[])this.array.Clone();
            this.array = new T[this.capacity];

            // Copy all the elements from 0 to index - 1
            for (int i = 0; i < index; i++)
            {
                this.array[i] = arrayClone[i];
            }

            // Copy all the elements from index + 1 to count - 1
            for (int i = index + 1; i < this.count; i++)
            {
                this.array[i - 1] = arrayClone[i];
            }

            this.count--;
        }

        // Insert(int index, T element) method - just like the List<T> Insert(int index, T element) method
        public void Insert(int index, T element)
        {
            if (index < 0 || index >= this.count || this.count == 0)
            {
                IndexOutOfRangeException indexOutOfRangeException = new IndexOutOfRangeException();
                throw new IndexOutOfRangeException(indexOutOfRangeException.Message);
            }

            T[] arrayClone = (T[])this.array.Clone();

            if (this.count == this.capacity)
            {
                this.array = new T[2 * this.capacity];
                this.capacity = 2 * this.capacity;
            }

            for (int i = 0; i < index; i++)
            {
                this.array[i] = arrayClone[i];
            }

            this.array[index] = element;

            for (int i = index + 1; i <= count ; i++)
            {
                this.array[i] = arrayClone[i - 1];
            }

            count++;
        }

        // Clear() method - just like the List<T> Clear() method
        public void Clear()
        {
            this.array = new T[this.capacity];
            this.count = 0;
        }

        // FindByValue(T elementValue) method - returns the index of the element
        // with the given value. Returns -1 if not found
        public int FindByValue(T elementValue)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (array[i].CompareTo(elementValue) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        // Override ToString()
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.count; i++)
            {
                result.Append(string.Format("{0} ", array[i]));
            }

            return result.ToString();
        }

        // Exercise 7 - define Min() and Max()
        public T Min()
        {
            T min = this.array[0];

            for (int i = 0; i < this.count; i++)
            {
                if (this.array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.array[0];

            for (int i = 1; i < this.count; i++)
            {
                if (this.array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}

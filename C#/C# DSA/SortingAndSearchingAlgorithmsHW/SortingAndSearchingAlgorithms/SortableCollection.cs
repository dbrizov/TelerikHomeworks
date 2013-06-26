namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public int LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(T item)
        {
            int leftIndex = 0;
            int rightIndex = this.items.Count - 1;
            int middleIndex = 0;

            while (leftIndex <= rightIndex)
            {
                middleIndex = (rightIndex + leftIndex) / 2;

                if (item.CompareTo(this.items[middleIndex]) < 0)
                {
                    rightIndex = middleIndex - 1;
                }
                else if (item.CompareTo(this.items[middleIndex]) > 0)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    return middleIndex;
                }
            }

            return -1;
        }

        // Fisher and Yates' algorithm - O(n) complexity
        public void Shuffle()
        {
            Random randomGenerator = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int randomIndex = randomGenerator.Next(i + 1);
                T temp = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    result.Append(this.items[i]);
                }
                else
                {
                    result.Append(" " + this.items[i]);
                }
            }

            return result.ToString();
        }
    }
}

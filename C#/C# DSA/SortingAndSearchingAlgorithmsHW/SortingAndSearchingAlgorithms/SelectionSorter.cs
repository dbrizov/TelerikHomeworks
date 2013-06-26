namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int indexOfMinElement = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[indexOfMinElement]) < 0)
                    {
                        indexOfMinElement = j;
                    }
                }

                T temp = collection[i];
                collection[i] = collection[indexOfMinElement];
                collection[indexOfMinElement] = temp;
            }
        }
    }
}

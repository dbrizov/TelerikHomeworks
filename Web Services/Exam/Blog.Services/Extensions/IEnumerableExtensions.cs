using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Services.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool ContainsAll<T>(this IEnumerable<T> collection, IEnumerable<T> items) where T : IComparable
        {
            bool containsAll = true;
            foreach (var tag in items)
            {
                if (!collection.Contains(tag))
                {
                    containsAll = false;
                    break;
                }
            }

            return containsAll;
        }
    }
}
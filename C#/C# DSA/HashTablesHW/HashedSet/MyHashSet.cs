using System;
using System.Collections;
using System.Collections.Generic;
using HashTable;

namespace HashedSet
{
    public class MyHashSet<T> : IEnumerable<T>
    {
        private MyHashTable<T, bool> items;

        public MyHashSet()
        {
            this.items = new MyHashTable<T, bool>();
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Add(T item)
        {
            this.items.Add(item, true);
        }

        public bool Remove(T item)
        {
            return this.items.Remove(item);
        }

        public bool Contains(T item)
        {
            return this.items.ContainsKey(item);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public void UnionWith(MyHashSet<T> otherSet)
        {
            var otherSetItems = otherSet.items.Keys;
            foreach (var item in otherSetItems)
            {
                if (!this.Contains(item))
                {
                    this.Add(item);
                }
            }
        }

        public void IntersectWith(MyHashSet<T> otherSet)
        {
            MyHashSet<T> newHashedSet = new MyHashSet<T>();
            var otherSetItems = otherSet.items.Keys;
            foreach (var item in otherSetItems)
            {
                if (this.Contains(item) && otherSet.Contains(item))
                {
                    newHashedSet.Add(item);
                }
            }

            this.items = newHashedSet.items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.items)
            {
                yield return pair.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

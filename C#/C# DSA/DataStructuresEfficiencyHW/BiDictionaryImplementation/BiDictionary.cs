using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace BiDictionaryImplementation
{
    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private MultiDictionary<TKey1, TValue> firstKeyDictionary;
        private MultiDictionary<TKey2, TValue> secondKeyDictionary;
        private MultiDictionary<Tuple<TKey1, TKey2>, TValue> bothKeysDictionary;

        public BiDictionary()
        {
            this.firstKeyDictionary = new MultiDictionary<TKey1, TValue>(true);
            this.secondKeyDictionary = new MultiDictionary<TKey2, TValue>(true);
            this.bothKeysDictionary = new MultiDictionary<Tuple<TKey1, TKey2>, TValue>(true);
        }

        public void Add(TKey1 firstKey, TKey2 secondKey, TValue value)
        {
            this.firstKeyDictionary.Add(firstKey, value);
            this.secondKeyDictionary.Add(secondKey, value);
            this.bothKeysDictionary.Add(new Tuple<TKey1, TKey2>(firstKey, secondKey), value);
        }

        public ICollection<TValue> FindByFirstKey(TKey1 key)
        {
            var elementsWithFirstKey = this.firstKeyDictionary[key];

            var tupleKeys = this.bothKeysDictionary.Keys;
            foreach (var tuple in tupleKeys)
            {
                if (tuple.Item1.Equals(key))
                {
                    foreach (var element in this.bothKeysDictionary[tuple])
                    {
                        if (!elementsWithFirstKey.Contains(element))
                        {
                            elementsWithFirstKey.Add(element);
                        }
                    }

                    break;
                }
            }

            return elementsWithFirstKey;
        }

        public ICollection<TValue> FindBySecondKey(TKey2 key)
        {
            var elementsWithSecondKey = this.secondKeyDictionary[key];

            var tupleKeys = this.bothKeysDictionary.Keys;
            foreach (var tuple in tupleKeys)
            {
                if (tuple.Item1.Equals(key))
                {
                    foreach (var element in this.bothKeysDictionary[tuple])
                    {
                        if (!elementsWithSecondKey.Contains(element))
                        {
                            elementsWithSecondKey.Add(element);
                        }
                    }

                    break;
                }
            }

            return elementsWithSecondKey;
        }

        public ICollection<TValue> FindByBothKeys(TKey1 firstKey, TKey2 secondKey)
        {
            // The Tuple.Equals method compares them by value, not by reference, so there will be not problem
            // if I pass as a key a new Tuple with the given keys (the references will be different, buth the values will be equal).
            var elements = this.bothKeysDictionary[new Tuple<TKey1, TKey2>(firstKey, secondKey)];

            return elements;
        }

        public bool ContainsFirstKey(TKey1 key)
        {
            return this.firstKeyDictionary.ContainsKey(key);
        }

        public bool ContainsSecondKey(TKey2 key)
        {
            return this.secondKeyDictionary.ContainsKey(key);
        }

        public bool ContainsKeyPair(TKey1 firstKey, TKey2 secondKey)
        {
            return this.bothKeysDictionary.ContainsKey(new Tuple<TKey1, TKey2>(firstKey, secondKey));
        }
    }
}

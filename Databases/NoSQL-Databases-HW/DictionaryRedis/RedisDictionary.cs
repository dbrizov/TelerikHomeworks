namespace _02.Redis_Dictionary_Implementation
{
    using ServiceStack.Redis;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RedisDictionary : IEnumerable<RedisDictItem>
    {
        private RedisClient client;
        private string dictionaryName;

        public RedisDictionary(RedisClient client, string dictionaryName)
        {
            this.client = client;
            this.dictionaryName = dictionaryName;
        }

        public void Add(string key, string value)
        {
            this.client.HSet(this.dictionaryName, key.ToAsciiCharArray(), value.ToAsciiCharArray());
        }

        public void Remove(string key)
        {
            if (ContainsKey(key))
            {
                this.client.HDel(this.dictionaryName, key.ToAsciiCharArray());
            }
            else
            {
                throw new ArgumentException("The key does not exist.");
            }
        }

        public bool ContainsKey(string key)
        {
            long containsValue = this.client.HExists(this.dictionaryName, key.ToAsciiCharArray());

            if (containsValue == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string this[string key]
        {
            get
            {
                byte[] valueToReturn = this.client.HGet(this.dictionaryName, key.ToAsciiCharArray());

                return valueToReturn.StringFromByteArray();
            }

            set
            {
                this.client.HSet(this.dictionaryName, key.ToAsciiCharArray(), value.ToAsciiCharArray());
            }
        }

        public IEnumerator<RedisDictItem> GetEnumerator()
        {
            byte[][] allValues = this.client.HGetAll(this.dictionaryName);

            for (int i = 0; i < allValues.Length; i+=2)
            {
                if (i >= allValues.Length)
                {
                    break;
                }
                yield return new RedisDictItem(allValues[i], allValues[i + 1]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

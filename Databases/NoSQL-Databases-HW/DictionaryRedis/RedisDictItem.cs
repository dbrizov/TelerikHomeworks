namespace _02.Redis_Dictionary_Implementation
{
    using System;

    public struct RedisDictItem
    {
        private string key;
        private string value;

        public RedisDictItem(byte[] key, byte[] value)
        {
            this.key = key.StringFromByteArray();
            this.value = value.StringFromByteArray();
        }

        public string Value
        {
            get { return value; }
        }
        
        public string Key
        {
            get { return key; }
        }
        
    }
}

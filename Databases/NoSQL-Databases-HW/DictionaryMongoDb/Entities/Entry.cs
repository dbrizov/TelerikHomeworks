using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DictionaryMongoDb.Entities
{
    public class Entry
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        public string Word { get; set; }

        [BsonRequired]
        public string Translation { get; set; }

        [BsonConstructor]
        public Entry(string word, string translation)
        {
            this.Word = word;
            this.Translation = translation;
        }
    }
}

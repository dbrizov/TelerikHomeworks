using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace MusicStoreDb.Client
{
    public static class XmlConverter
    {
        public static string SerializeObject(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
        }

        public static T DeserializeObject<T>(string xmlString)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(xmlString))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}

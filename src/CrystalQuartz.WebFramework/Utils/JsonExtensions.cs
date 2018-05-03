using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CrystalQuartz.WebFramework.Utils
{
    public static class JsonExtensions
    {
        static readonly JsonSerializerSettings DefaultSettigns = new JsonSerializerSettings();
        public static string Serialize(this JsonSerializer serializer, object obj, JsonSerializerSettings settings = null)
        {
            var stringBuilder = new StringBuilder();
            using (var textWriter = new StringWriter(stringBuilder))
            {
                serializer.Serialize(new JsonTextWriter(textWriter), obj);
            }
            return stringBuilder.ToString();
        }

        public static TData Deserialize<TData>(this JsonSerializer serializer, string data)
        {
            using (var reader = new JsonTextReader(new StringReader(data)))
            {
                return serializer.Deserialize<TData>(reader);
            }
        }

        public static object Deserialize(this JsonSerializer serializer, string data)
        {
            using (var reader = new JsonTextReader(new StringReader(data)))
            {
                return serializer.Deserialize(reader);
            }
        }

        public static object Deserialize(this JsonSerializer serializer, Type type, string data)
        {
            using (var reader = new JsonTextReader(new StringReader(data)))
            {
                return serializer.Deserialize(reader, type);
            }
        }
    }
}

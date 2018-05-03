using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrystalQuartz.Application
{
    using System;
    using System.Collections.Generic;
    using CrystalQuartz.Core.Domain;

    public class ActivityStatusConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var status = (ActivityStatus)value;
            var o = JObject.FromObject(new
            {
                Value = (int)status,
                Code = status.ToString().ToLower(),
                Name = status.ToString()
            });
            o.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ActivityStatus);
        }
    }
}
using System;
using CrystalQuartz.Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrystalQuartz.Application
{
    internal class DateTimeConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                return;
            }

            var date = GetDate(value);

            var o = JObject.FromObject(new
            {
                Ticks = date.UnixTicks(),
                UtcDateStr = date.ToString("G"),
                ServerDateStr = date.ToLocalTime().ToString("G")
            });
            o.WriteTo(writer);
        }

        private DateTime GetDate(object obj)
        {
            if (obj is DateTime)
            {
                return (DateTime) obj;
            }

            throw new Exception("Unexpected date value " + obj);
        }
    }
}
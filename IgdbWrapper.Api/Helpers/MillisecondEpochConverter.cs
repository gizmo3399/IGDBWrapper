using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace IgdbWrapper.Api.Helpers
{
    /// <summary>
    /// <see cref="DateTime"/> converter for JSON.NET that converts Unix style timestamps to C# <see cref="DateTime"/> objects.
    /// This converter is based on Milliseconds from Epoch.
    /// </summary>
    /// <inheritdoc cref="DateTimeConverterBase"/>
    public class MillisecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - Epoch).TotalMilliseconds + "");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return Epoch.AddMilliseconds((long)reader.Value);
        }
    }
}
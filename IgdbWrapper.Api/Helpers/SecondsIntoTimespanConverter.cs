using Newtonsoft.Json;
using System;

namespace IgdbWrapper.Api.Helpers
{
    /// <summary>
    /// Converter for JSON.NET that converts a <see cref="Int64"/> value into a <see cref="TimeSpan"/>.
    /// The <see cref="Int64"/> value are assumed to be seconds by this converter.
    /// </summary>
    /// <inheritdoc cref="JsonConverter"/>
    public class SecondsIntoTimespanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null || reader.ValueType != typeof(long))
                return TimeSpan.Zero;
            return TimeSpan.FromSeconds((long)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.Seconds.ToString());
        }
    }
}
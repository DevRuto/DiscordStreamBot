using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordStreamBot.Serialization
{
    public class LongConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(long));
            return long.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

}
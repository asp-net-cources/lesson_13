using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Lesson13.JsonSettings.Converters;

public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        return DateTime.ParseExact(reader.GetString()!, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
    }
    public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options) {
        writer.WriteStringValue(dateTimeValue.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
    }
}
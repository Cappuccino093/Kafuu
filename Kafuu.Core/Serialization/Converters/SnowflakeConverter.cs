namespace Kafuu.Core.Serialization.Converters;

public class SnowflakeConverter : JsonConverter<Snowflake>
{
	public override Snowflake Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) =>
		new(Convert.ToUInt64(reader.GetString()));

	public override void Write(
		Utf8JsonWriter writer,
		Snowflake snowflake,
		JsonSerializerOptions options) =>
		writer.WriteStringValue(snowflake.Value.ToString());
}

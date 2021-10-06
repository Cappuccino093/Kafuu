namespace Kafuu.Core.Serialization.Converters;

public class ColorConverter : JsonConverter<Color>
{
	public override Color Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) =>
		Color.FromArgb(Convert.ToInt32(reader.GetString()));

	public override void Write(
		Utf8JsonWriter writer,
		Color value,
		JsonSerializerOptions options) =>
		writer.WriteNumberValue(value.ToArgb());
}

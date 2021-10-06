namespace Kafuu.Core.Serialization.Converters;

public class OptionalConverter : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
		=> !typeToConvert.IsGenericType ? false : typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		Type valueType = typeToConvert.GetGenericArguments()[0];

		return (JsonConverter)Activator.CreateInstance(
			type: typeof(OptionalConverterInner<>).MakeGenericType(new Type[] { valueType }),
			bindingAttr: BindingFlags.Instance | BindingFlags.Public,
			binder: null,
			args: null,
			culture: null
		);
	}

	private class OptionalConverterInner<T> : JsonConverter<Optional<T>>
	{
		public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			T value = JsonSerializer.Deserialize<T>(ref reader, options);
			return new Optional<T>(value);
		}

		public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}
}

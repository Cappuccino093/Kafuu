using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

namespace Kafuu.Core.Serialization.Converters;

public class IInteractionDataConverter : JsonConverter<IInteractionData>
{
	public override bool CanConvert(Type typeToConvert)
		=> typeof(IInteractionData).IsAssignableFrom(typeToConvert);

	public override IInteractionData Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options)
	{
		if (JsonDocument.TryParseValue(ref reader, out JsonDocument? doc))
		{
			if (doc.RootElement.TryGetProperty("type", out JsonElement jsonElementType))
			{
				byte jsonElementTypeValue = jsonElementType.GetByte();
				string rootElement = doc.RootElement.GetRawText();

				switch ((ApplicationCommandType)jsonElementTypeValue)
				{
					case ApplicationCommandType.ChatInput:
					{
						return JsonSerializer.Deserialize<ApplicationCommandInteractionData>(rootElement, options);
					}
					case ApplicationCommandType.User:
					{
						return JsonSerializer.Deserialize<UserCommandInteractionData>(rootElement, options);
					}

					case ApplicationCommandType.Message:
					{
						return JsonSerializer.Deserialize<MessageCommandInteractionData>(rootElement, options);
					}
				}
			}

			if (doc.RootElement.TryGetProperty("custom_id", out _)
				|| doc.RootElement.TryGetProperty("component_type", out _)
				|| doc.RootElement.TryGetProperty("values", out _))
			{
				string rootElement = doc.RootElement.GetRawText();

				return JsonSerializer.Deserialize<ComponentInteractionData>(rootElement, options);
			}
		}

		throw new JsonException("Failed conversion.");
	}

	public override void Write(Utf8JsonWriter writer, IInteractionData value, JsonSerializerOptions options) { }
}

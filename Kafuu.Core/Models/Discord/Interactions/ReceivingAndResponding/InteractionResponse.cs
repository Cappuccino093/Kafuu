namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record InteractionResponse
{
	[JsonPropertyName("type")]
	public InteractionCallbackType Type { get; private init; }

	[JsonPropertyName("data"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<InteractionCallbackData> Data { get; init; }

	public InteractionResponse(
		InteractionCallbackType type,
		Optional<InteractionCallbackData> data = default)
	{
		this.Type = type;
		this.Data = data;
	}
}

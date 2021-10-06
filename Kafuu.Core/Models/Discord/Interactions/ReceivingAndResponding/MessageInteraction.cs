using Kafuu.Core.Models.Discord.Resources.User;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record MessageInteraction
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("type")]
	public InteractionType Type { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("user")]
	public User User { get; private init; }

	public MessageInteraction(Snowflake id, InteractionType type, string name, User user)
	{
		this.Id = id;
		this.Type = type;
		this.Name = name;
		this.User = user;
	}
}

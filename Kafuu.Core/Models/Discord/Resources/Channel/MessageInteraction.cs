using Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record MessageInteraction
{
	[JsonPropertyName("id")]
	public int Id { get; private init; }

	[JsonPropertyName("type")]
	public InteractionType Type { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("user")]
	public User.User User { get; private init; }

	public MessageInteraction(int id, InteractionType type, string name, User.User user)
	{
		this.Id = id;
		this.Type = type;
		this.Name = name;
		this.User = user;
	}
}

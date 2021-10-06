namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record MessageActivity
{
	[JsonPropertyName("type")]
	public MessageActivityType Type { get; private init; }

	[JsonPropertyName("party_id")]
	public string PartyId { get; private init; }

	public MessageActivity(MessageActivityType type, string partyId)
	{
		this.Type = type;
		this.PartyId = partyId;
	}
}

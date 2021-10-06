namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record Reaction
{
	[JsonPropertyName("count")]
	public int Count { get; private init; }

	[JsonPropertyName("me")]
	public bool Me { get; private init; }

	[JsonPropertyName("emoji")]
	public Emoji.Emoji Emoji { get; private init; }

	public Reaction(int count, bool me, Emoji.Emoji emoji)
	{
		this.Count = count;
		this.Me = me;
		this.Emoji = emoji;
	}
}

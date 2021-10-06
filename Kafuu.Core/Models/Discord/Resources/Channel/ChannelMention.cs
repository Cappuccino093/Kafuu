namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record ChannelMention
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("guild_id")]
	public Snowflake GuildId { get; private init; }

	[JsonPropertyName("type")]
	public ChannelType Type { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	public ChannelMention(Snowflake id, Snowflake guildId, ChannelType type, string name)
	{
		this.Id = id;
		this.GuildId = guildId;
		this.Type = type;
		this.Name = name;
	}
}

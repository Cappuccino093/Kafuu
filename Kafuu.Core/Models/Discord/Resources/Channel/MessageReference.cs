namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record MessageReference
{
	[JsonPropertyName("message_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> MessageId { get; init; }

	[JsonPropertyName("channel_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> ChannelId { get; init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; init; }

	[JsonPropertyName("fail_if_not_exists"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> FailIfNotExists { get; init; }

	public MessageReference(
		Optional<Snowflake> messageId = default,
		Optional<Snowflake> channelId = default,
		Optional<Snowflake> guildId = default,
		Optional<bool> failIfNotExists = default)
	{
		this.MessageId = messageId;
		this.ChannelId = channelId;
		this.GuildId = guildId;
		this.FailIfNotExists = failIfNotExists;
	}
}

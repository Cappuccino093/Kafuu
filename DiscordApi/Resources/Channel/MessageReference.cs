namespace DiscordApi.Resources.Channel;

public record MessageReference
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> MessageId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> ChannelId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> GuildId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> FailIfNotExists { get; init; }

    public MessageReference(
        Optional<Snowflake> messageId,
        Optional<Snowflake> channelId,
        Optional<Snowflake> guildId,
        Optional<bool> failIfNotExists) =>
        (MessageId, ChannelId, GuildId, FailIfNotExists) =
        (messageId, channelId, guildId, failIfNotExists);
}

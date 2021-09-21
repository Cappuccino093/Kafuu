namespace DiscordApi.Resources.Channel;

public record ChannelMention
{
    public Snowflake Id { get; }
    public Snowflake GuildId { get; }
    public ChannelType Type { get; }
    public string Name { get; }

    public ChannelMention(Snowflake id, Snowflake guildId, ChannelType type, string name) =>
        (Id, GuildId, Type, Name) = (id, guildId, type, name);
}

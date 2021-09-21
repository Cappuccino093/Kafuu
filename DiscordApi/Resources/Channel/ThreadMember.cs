namespace DiscordApi.Resources.Channel;

public record ThreadMember
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> UserId { get; init; }

    public DateTime JoinTimestamp { get; }
    public int Flags { get; }

    public ThreadMember(
        DateTime joinTimestamp,
        int flags,
        Optional<Snowflake> id = default,
        Optional<Snowflake> userId = default) =>
        (Id, UserId, JoinTimestamp, Flags) =
        (id, userId, joinTimestamp, flags);
}

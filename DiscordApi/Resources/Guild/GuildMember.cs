namespace DiscordApi.Resources.Guild;

public record GuildMember
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<User.User> User { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> Nick { get; init; }

    public Snowflake[] Roles { get; }
    public DateTime JoinedAt { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<DateTime?> PremiumSince { get; init; }

    public bool Deaf { get; }
    public bool Mute { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Pending { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Permissions { get; init; }

    public GuildMember(
        Snowflake[] roles,
        DateTime joinedAt,
        bool deaf,
        bool mute,
        Optional<User.User> user = default,
        Optional<string?> nick = default,
        Optional<DateTime?> premiumSince = default,
        Optional<bool> pending = default,
        Optional<string> permissions = default) =>
        (User, Nick, Roles, JoinedAt, PremiumSince, Deaf, Mute, Pending, Permissions) =
        (user, nick, roles, joinedAt, premiumSince, deaf, mute, pending, permissions);
}

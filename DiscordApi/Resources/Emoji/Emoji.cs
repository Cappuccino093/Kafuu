using DiscordApi.Topics.Permissions;

namespace DiscordApi.Resources.Emoji;

public record Emoji
{
    public Snowflake? Id { get; }
    public string? Name { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Role> Roles { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<User.User> User { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> RequireColons { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Managed { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Animated { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Available { get; init; }

    public Emoji(
        Snowflake? id,
        string? name,
        Optional<Role> roles = default,
        Optional<User.User> user = default,
        Optional<bool> requireColons = default,
        Optional<bool> managed = default,
        Optional<bool> animated = default,
        Optional<bool> available = default) =>
        (Id, Name, Roles, User, RequireColons, Managed, Animated, Available) =
        (id, name, roles, user, requireColons, managed, animated, available);
}

namespace DiscordApi.Topics.Permissions;

public record Role
{
    public Snowflake Id { get; }
    public string Name { get; }
    public int Color { get; }
    public bool Hoist { get; }
    public int Position { get; }
    public string Permissions { get; }
    public bool Managed { get; }
    public bool Mentionable { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RoleTags? Tags { get; init; }

    public Role(
        Snowflake id,
        string name,
        int color,
        bool hoist,
        int position,
        string permissions,
        bool managed,
        bool mentionable,
        RoleTags? tags) =>
        (Id, Name, Color, Hoist, Position, Permissions, Managed, Mentionable, Tags) =
        (id, name, color, hoist, position, permissions, managed, mentionable, tags);
}

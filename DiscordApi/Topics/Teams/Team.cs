namespace DiscordApi.Topics.Teams;

public record Team
{
    public string? Icon { get; }
    public Snowflake Id { get; }
    public TeamMember[] Members { get; }
    public string Name { get; }
    public Snowflake OwnerUserId { get; }

    public Team(string? icon, Snowflake id, TeamMember[] members, string name, Snowflake ownerUserId) =>
        (Icon, Id, Members, Name, OwnerUserId) = (icon, id, members, name, ownerUserId);
}

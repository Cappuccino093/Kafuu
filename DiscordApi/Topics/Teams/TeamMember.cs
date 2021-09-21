using DiscordApi.Resources.User;

namespace DiscordApi.Topics.Teams;

public record TeamMember
{
    public MembershipState MembershipState { get; }
    public string[] Permissions { get; }
    public Snowflake TeamId { get; }
    public User User { get; }

    public TeamMember(MembershipState membershipState, string[] permissions, Snowflake teamId, User user) =>
        (MembershipState, Permissions, TeamId, User) = (membershipState, permissions, teamId, user);
}

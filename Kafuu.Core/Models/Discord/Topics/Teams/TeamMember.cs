using Kafuu.Core.Models.Discord.Resources.User;

namespace Kafuu.Core.Models.Discord.Topics.Teams;

public record TeamMember
{
	[JsonPropertyName("membership_state")]
	public MembershipState MembershipState { get; private init; }

	[JsonPropertyName("permissions")]
	public string[] Permissions { get; private init; }

	[JsonPropertyName("team_id")]
	public Snowflake TeamId { get; private init; }

	[JsonPropertyName("user")]
	public User User { get; private init; }

	public TeamMember(MembershipState membershipState, string[] permissions, Snowflake teamId, User user)
	{
		this.MembershipState = membershipState;
		this.Permissions = permissions;
		this.TeamId = teamId;
		this.User = user;
	}
}

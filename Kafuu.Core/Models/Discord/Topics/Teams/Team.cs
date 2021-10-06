namespace Kafuu.Core.Models.Discord.Topics.Teams;

public record Team
{
	[JsonPropertyName("icon")]
	public string? Icon { get; private init; }

	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("members")]
	public TeamMember[] Members { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("owner_user_id")]
	public Snowflake OwnerUserId { get; private init; }

	public Team(string? icon, Snowflake id, TeamMember[] members, string name, Snowflake ownerUserId)
	{
		this.Icon = icon;
		this.Id = id;
		this.Members = members;
		this.Name = name;
		this.OwnerUserId = ownerUserId;
	}
}

namespace Kafuu.Core.Models.Discord.Resources.Guild;

public record GuildMember : IGuildMember
{
	[JsonPropertyName("user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<User.User> User { get; init; }

	[JsonPropertyName("nick"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string?> Nick { get; init; }

	[JsonPropertyName("roles")]
	public Snowflake[] Roles { get; private init; }

	[JsonPropertyName("joined_at")]
	public DateTime JoinedAt { get; private init; }

	[JsonPropertyName("premium_since"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<DateTime?> PremiumSince { get; init; }
	
	[JsonPropertyName("deaf")]
	public bool Deaf { get; private init; }

	[JsonPropertyName("mute")]
	public bool Mute { get; private init; }

	[JsonPropertyName("pending"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Pending { get; init; }

	[JsonPropertyName("permissions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
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
		Optional<string> permissions = default)
	{
		this.User = user;
		this.Nick = nick;
		this.Roles = roles;
		this.JoinedAt = joinedAt;
		this.PremiumSince = premiumSince;
		this.Deaf = deaf;
		this.Mute = mute;
		this.Pending = pending;
		this.Permissions = permissions;
	}
}

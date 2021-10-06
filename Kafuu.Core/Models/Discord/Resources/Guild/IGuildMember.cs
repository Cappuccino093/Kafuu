namespace Kafuu.Core.Models.Discord.Resources.Guild;

public interface IGuildMember
{
	public Optional<User.User> User { get; init; }
	public Optional<string?> Nick { get; init; }
	public Snowflake[] Roles { get; }
	public DateTime JoinedAt { get; }
	public Optional<DateTime?> PremiumSince { get; init; }
	public bool Deaf { get; }
	public bool Mute { get; }
	public Optional<bool> Pending { get; init; }
	public Optional<string> Permissions { get; init; }
}

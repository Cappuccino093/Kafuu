namespace Kafuu.Core.Models.Discord.Resources.User;

public interface IUser
{
	public Snowflake Id { get; }
	public string Username { get; }
	public string Discriminator { get; }
	public string? Avatar { get; }
	public Optional<bool> Bot { get; init; }
	public Optional<bool> System { get; init; }
	public Optional<bool> MfaEnabled { get; init; }
	public Optional<string?> Banner { get; init; }
	public Optional<int?> AccentColor { get; init; }
	public Optional<string> Locale { get; init; }
	public Optional<bool> Verified { get; init; }
	public Optional<string?> Email { get; init; }
	public Optional<int> Flags { get; init; }
	public Optional<int> PremiumType { get; init; }
	public Optional<int> PublicFlags { get; init; }
}

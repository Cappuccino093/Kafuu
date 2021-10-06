namespace Kafuu.Core.Models.Discord.Resources.User;

public record User : IUser
{
	private string _username;

	[JsonPropertyName("id")]
	public Snowflake Id { get; init; }

	[JsonPropertyName("username")]
	public string Username
	{
		get => this._username;
		init
		{
			if (value.Length is not (>= 2 and <= 32))
				throw new ArgumentException("Usernames must be between 2 and 32 characters long.");

			this._username = value;
		}
	}

	[JsonPropertyName("discriminator")]
	public string Discriminator { get; init; }

	[JsonPropertyName("avatar")]
	public string? Avatar { get; init; }

	[JsonPropertyName("bot"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Bot { get; init; }

	[JsonPropertyName("system"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> System { get; init; }

	[JsonPropertyName("mfa_enabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> MfaEnabled { get; init; }

	[JsonPropertyName("banner"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string?> Banner { get; init; }

	[JsonPropertyName("accent_color"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int?> AccentColor { get; init; }

	[JsonPropertyName("locale"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Locale { get; init; }

	[JsonPropertyName("verified"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Verified { get; init; }

	[JsonPropertyName("email"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string?> Email { get; init; }

	[JsonPropertyName("flags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Flags { get; init; }

	[JsonPropertyName("premium_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> PremiumType { get; init; }

	[JsonPropertyName("public_flags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> PublicFlags { get; init; }
}

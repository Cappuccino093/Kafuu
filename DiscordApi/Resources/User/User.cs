namespace DiscordApi.Resources.User;

public record User
{
    private string _username;

    public Snowflake Id { get; }

    public string Username
    {
        get => _username;
        private init
        {
            if (!(value.Length >= 2 && value.Length <= 32))
                throw new ArgumentException("Usernames must be between 2 and 32 characters long.");

            _username = value;
        }
    }

    public string Discriminator { get; }
    public string? Avatar { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Bot { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> System { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> MfaEnabled { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> Banner { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int?> AccentColor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Locale { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Verified { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> Email { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Flags { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> PremiumType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> PublicFlags { get; init; }

    public User(
        Snowflake id,
        string username,
        string discriminator,
        string? avatar,
        Optional<bool> bot = default,
        Optional<bool> system = default,
        Optional<bool> mfaEnabled = default,
        Optional<string?> banner = default,
        Optional<int?> accentColor = default,
        Optional<string> locale = default,
        Optional<bool> verified = default,
        Optional<string?> email = default,
        Optional<int> flags = default,
        Optional<int> premiumType = default,
        Optional<int> publicFlags = default) =>
        (Id, Username, Discriminator, Avatar, Bot, System, MfaEnabled, Banner, AccentColor, Locale, Verified, Email, Flags, PremiumType, PublicFlags) =
        (id, username, discriminator, avatar, bot, system, mfaEnabled, banner, accentColor, locale, verified, email, flags, premiumType, publicFlags);
}

using DiscordApi.Topics.Teams;

namespace DiscordApi.Resources.Application;

public record Application
{
    public Snowflake Id { get; }
    public string Name { get; }
    public string? Icon { get; }
    public string Description { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri[]> RpcOrigins { get; init; }

    public bool BotPublic { get; }
    public bool BotRequireCodeGrant { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> TermsOfServiceUrl { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> PrivacyPolicyUrl { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<User.User> Owner { get; init; }

    public string Summary { get; }
    public string VerifyKey { get; }
    public Team? Team { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> GuildId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> PrimarySkuId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Slug { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> CoverImage { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Flags { get; init; }

    public Application(
        Snowflake id,
        string name,
        string? icon,
        string description,
        Uri[] rpcOrigins,
        bool botPublic,
        bool botRequireCodeGrant,
        string summary,
        string verifyKey,
        Team? team,
        Optional<Uri> termsOfServiceUrl = default,
        Optional<Uri> privacyPolicyUrl = default,
        Optional<User.User> owner = default,
        Optional<Snowflake> guildId = default,
        Optional<Snowflake> primarySkuId = default,
        Optional<string> slug = default,
        Optional<string> coverImage = default,
        Optional<int> flags = default)
    {
        Id = id;
        Name = name;
        Icon = icon;
        Description = description;
        RpcOrigins = rpcOrigins;
        BotPublic = botPublic;
        BotRequireCodeGrant = botRequireCodeGrant;
        TermsOfServiceUrl = termsOfServiceUrl;
        PrivacyPolicyUrl = privacyPolicyUrl;
        Owner = owner;
        Summary = summary;
        VerifyKey = verifyKey;
        Team = team;
        GuildId = guildId;
        PrimarySkuId = primarySkuId;
        Slug = slug;
        CoverImage = coverImage;
        Flags = flags;
    }
}

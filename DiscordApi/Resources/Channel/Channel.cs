namespace DiscordApi.Resources.Channel;

public record Channel
{
    public Snowflake Id { get; }
    public ChannelType Type { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> GuildId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Position { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Overwrite[]> PermissionOverwrites { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> Topic { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Nsfw { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake?> LastMessageId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Bitrate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> UserLimit { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> RateLimitPerUser { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<User.User[]> Recipients { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> Icon { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> OwnerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> ApplicationId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake?> ParentId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<DateTime?> LastPinTimestamp { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> RtcRegion { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> VideoQualityMode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> MessageCount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> MemberCount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ThreadMetadata> ThreadMetadata { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ThreadMember> Member { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> DefaultAutoArchiveDuration { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Permissions { get; init; }

    public Channel(
        Snowflake id,
        ChannelType type,
        Optional<Snowflake> guildId = default,
        Optional<int> position = default,
        Optional<Overwrite[]> permissionOverwrites = default,
        Optional<string> name = default,
        Optional<string?> topic = default,
        Optional<bool> nsfw = default,
        Optional<Snowflake?> lastMessageId = default,
        Optional<int> bitrate = default,
        Optional<int> userLimit = default,
        Optional<int> rateLimitPerUser = default,
        Optional<User.User[]> recipients = default,
        Optional<string?> icon = default,
        Optional<Snowflake> ownerId = default,
        Optional<Snowflake> applicationId = default,
        Optional<Snowflake?> parentId = default,
        Optional<DateTime?> lastPinTimestamp = default,
        Optional<string?> rtcRegion = default,
        Optional<int> videoQualityMode = default,
        Optional<int> messageCount = default,
        Optional<int> memberCount = default,
        Optional<ThreadMetadata> threadMetadata = default,
        Optional<ThreadMember> member = default,
        Optional<int> defaultAutoArchiveDuration = default,
        Optional<string> permissions = default)
    {
        Id = id;
        Type = type;
        GuildId = guildId;
        Position = position;
        PermissionOverwrites = permissionOverwrites;
        Name = name;
        Topic = topic;
        Nsfw = nsfw;
        LastMessageId = lastMessageId;
        Bitrate = bitrate;
        UserLimit = userLimit;
        RateLimitPerUser = rateLimitPerUser;
        Recipients = recipients;
        Icon = icon;
        OwnerId = ownerId;
        ApplicationId = applicationId;
        ParentId = parentId;
        LastPinTimestamp = lastPinTimestamp;
        RtcRegion = rtcRegion;
        VideoQualityMode = videoQualityMode;
        MessageCount = messageCount;
        MemberCount = memberCount;
        ThreadMetadata = threadMetadata;
        Member = member;
        DefaultAutoArchiveDuration = defaultAutoArchiveDuration;
        Permissions = permissions;
    }
}

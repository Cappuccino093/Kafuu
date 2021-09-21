using DiscordApi.Resources.Guild;

namespace DiscordApi.Resources.Channel;

public record Message
{
    private object _nonce;

    public Snowflake Id { get; }
    public Snowflake ChannelId { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> GuildId { get; init; }

    public AuthorUser Author { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<GuildMember> Member { get; init; }

    public string Content { get; }
    public DateTime Timestamp { get; }
    public DateTime? EditedTimestamp { get; }
    public bool Tts { get; }
    public bool MentionEveryone { get; }
    public MentionUser[] Mentions { get; }
    public Snowflake[] MentionRoles { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ChannelMention[]> MentionChannels { get; init; }

    public Attachment[] Attachments { get; }
    public Embed[] Embeds { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Reaction[]> Reactions { get; init; }

    public Optional<object> Nonce
    {
        get => _nonce;
        init
        {
            if (!(value is int || value is string))
                throw new ArgumentException("Nonce must be an integer or string.");

            _nonce = value;
        }
    }

    public bool Pinned { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> WebhookId { get; init; }

    public MessageType Type { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<MessageActivity> Activity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Application.Application> Application { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> ApplicationId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<MessageReference> MessageReference { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Flags { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Message?> ReferencedMessage { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Channel> Channel { get; init; }

    //[JsonPropertyName("components"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    //public Optional<>


    public record AuthorUser : User.User
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public new Optional<string> Discriminator { get; init; }

        public AuthorUser(
            Snowflake id,
            string username,
            string? avatar,
            Optional<string> discriminator = default,
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
            Optional<int> publicFlags = default) :
            base(
                id,
                username,
                default,
                avatar,
                bot,
                system,
                mfaEnabled,
                banner,
                accentColor,
                locale,
                verified,
                email,
                flags,
                premiumType,
                publicFlags) =>
            Discriminator = discriminator;
    }

    public record MentionUser : User.User
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Optional<GuildMember> Member { get; init; }

        public MentionUser(
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
            Optional<int> publicFlags = default,
            Optional<GuildMember> member = default) :
            base(
                id,
                username,
                discriminator,
                avatar,
                bot,
                system,
                mfaEnabled,
                banner,
                accentColor,
                locale,
                verified,
                email,
                flags,
                premiumType,
                publicFlags) =>
            Member = member;
    }

}

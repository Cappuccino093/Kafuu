namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record Channel : IChannel
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("type")]
	public ChannelType Type { get; private init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; init; }

	[JsonPropertyName("position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Position { get; init; }

	[JsonPropertyName("permission_overwrites"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Overwrite[]> PermissionOverwrites { get; init; }

	[JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Name { get; init; }

	[JsonPropertyName("topic"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string?> Topic { get; init; }

	[JsonPropertyName("nsfw"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Nsfw { get; init; }

	[JsonPropertyName("last_message_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake?> LastMessageId { get; init; }

	[JsonPropertyName("content_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Bitrate { get; init; }

	[JsonPropertyName("user_limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> UserLimit { get; init; }

	[JsonPropertyName("rate_limit_per_user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> RateLimitPerUser { get; init; }

	[JsonPropertyName("recipients"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<User.User[]> Recipients { get; init; }

	[JsonPropertyName("icon"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string?> Icon { get; init; }

	[JsonPropertyName("owner_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> OwnerId { get; init; }

	[JsonPropertyName("application_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> ApplicationId { get; init; }

	[JsonPropertyName("parent_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake?> ParentId { get; init; }

	[JsonPropertyName("last_pin_timestamp"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<DateTime?> LastPinTimestamp { get; init; }

	[JsonPropertyName("rtc_region"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string?> RtcRegion { get; init; }

	[JsonPropertyName("video_quality_mode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> VideoQualityMode { get; init; }

	[JsonPropertyName("message_count"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> MessageCount { get; init; }

	[JsonPropertyName("member_count"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> MemberCount { get; init; }

	[JsonPropertyName("thread_metadata"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ThreadMetadata> ThreadMetadata { get; init; }

	[JsonPropertyName("member"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ThreadMember> Member { get; init; }

	[JsonPropertyName("default_auto_archive_duration"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> DefaultAutoArchiveDuration { get; init; }

	[JsonPropertyName("permissions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
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
		this.Id = id;
		this.Type = type;
		this.GuildId = guildId;
		this.Position = position;
		this.PermissionOverwrites = permissionOverwrites;
		this.Name = name;
		this.Topic = topic;
		this.Nsfw = nsfw;
		this.LastMessageId = lastMessageId;
		this.Bitrate = bitrate;
		this.UserLimit = userLimit;
		this.RateLimitPerUser = rateLimitPerUser;
		this.Recipients = recipients;
		this.Icon = icon;
		this.OwnerId = ownerId;
		this.ApplicationId = applicationId;
		this.ParentId = parentId;
		this.LastPinTimestamp = lastPinTimestamp;
		this.RtcRegion = rtcRegion;
		this.VideoQualityMode = videoQualityMode;
		this.MessageCount = messageCount;
		this.MemberCount = memberCount;
		this.ThreadMetadata = threadMetadata;
		this.Member = member;
		this.DefaultAutoArchiveDuration = defaultAutoArchiveDuration;
		this.Permissions = permissions;
	}
}

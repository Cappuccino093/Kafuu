namespace Kafuu.Core.Models.Discord.Resources.Channel;

public interface IChannel
{
	public Snowflake Id { get; }
	public ChannelType Type { get; }
	public Optional<Snowflake> GuildId { get; init; }
	public Optional<int> Position { get; init; }
	public Optional<Overwrite[]> PermissionOverwrites { get; init; }
	public Optional<string> Name { get; init; }
	public Optional<string?> Topic { get; init; }
	public Optional<bool> Nsfw { get; init; }
	public Optional<Snowflake?> LastMessageId { get; init; }
	public Optional<int> Bitrate { get; init; }
	public Optional<int> UserLimit { get; init; }
	public Optional<int> RateLimitPerUser { get; init; }
	public Optional<User.User[]> Recipients { get; init; }
	public Optional<string?> Icon { get; init; }
	public Optional<Snowflake> OwnerId { get; init; }
	public Optional<Snowflake> ApplicationId { get; init; }
	public Optional<Snowflake?> ParentId { get; init; }
	public Optional<DateTime?> LastPinTimestamp { get; init; }
	public Optional<string?> RtcRegion { get; init; }
	public Optional<int> VideoQualityMode { get; init; }
	public Optional<int> MessageCount { get; init; }
	public Optional<int> MemberCount { get; init; }
	public Optional<ThreadMetadata> ThreadMetadata { get; init; }
	public Optional<ThreadMember> Member { get; init; }
	public Optional<int> DefaultAutoArchiveDuration { get; init; }
	public Optional<string> Permissions { get; init; }
}

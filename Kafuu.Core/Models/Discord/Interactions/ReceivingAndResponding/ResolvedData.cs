using Kafuu.Core.Models.Discord.Interactions.MessageComponents;
using Kafuu.Core.Models.Discord.Resources.Channel;
using Kafuu.Core.Models.Discord.Resources.Guild;
using Kafuu.Core.Models.Discord.Resources.Sticker;
using Kafuu.Core.Models.Discord.Resources.User;
using Kafuu.Core.Models.Discord.Topics.Permissions;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record ResolvedData
{
	[JsonPropertyName("users"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Dictionary<Snowflake, User>> Users { get; init; }

	[JsonPropertyName("members"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Dictionary<Snowflake, PartialGuildMember>> Members { get; init; }

	[JsonPropertyName("roles"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Dictionary<Snowflake, Role>> Roles { get; init; }

	[JsonPropertyName("channels"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Dictionary<Snowflake, PartialChannel>> Channels { get; init; }

	[JsonPropertyName("messages"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Dictionary<Snowflake, PartialMessage>> Messages { get; init; }

	public ResolvedData(
		Optional<Dictionary<Snowflake, User>> users = default,
		Optional<Dictionary<Snowflake, PartialGuildMember>> members = default,
		Optional<Dictionary<Snowflake, Role>> roles = default,
		Optional<Dictionary<Snowflake, PartialChannel>> channels = default,
		Optional<Dictionary<Snowflake, PartialMessage>> messages = default)
	{
		this.Users = users;
		this.Members = members;
		this.Roles = roles;
		this.Channels = channels;
		this.Messages = messages;
	}

	public record PartialChannel : IChannel
	{
		[JsonPropertyName("id")]
		public Snowflake Id { get; private init; }

		[JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<string> Name { get; init; }

		[JsonPropertyName("type")]
		public ChannelType Type { get; private init; }

		[JsonPropertyName("permissions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<string> Permissions { get; init; }

		[JsonPropertyName("thread_metadata"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<ThreadMetadata> ThreadMetadata { get; init; }

		[JsonPropertyName("parent_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<Snowflake?> ParentId { get; init; }

		Optional<Snowflake> IChannel.GuildId { get; init; }
		Optional<int> IChannel.Position { get; init; }
		Optional<Overwrite[]> IChannel.PermissionOverwrites { get; init; }
		Optional<string?> IChannel.Topic { get; init; }
		Optional<bool> IChannel.Nsfw { get; init; }
		Optional<Snowflake?> IChannel.LastMessageId { get; init; }
		Optional<int> IChannel.Bitrate { get; init; }
		Optional<int> IChannel.UserLimit { get; init; }
		Optional<int> IChannel.RateLimitPerUser { get; init; }
		Optional<User[]> IChannel.Recipients { get; init; }
		Optional<string?> IChannel.Icon { get; init; }
		Optional<Snowflake> IChannel.OwnerId { get; init; }
		Optional<Snowflake> IChannel.ApplicationId { get; init; }
		Optional<DateTime?> IChannel.LastPinTimestamp { get; init; }
		Optional<string?> IChannel.RtcRegion { get; init; }
		Optional<int> IChannel.VideoQualityMode { get; init; }
		Optional<int> IChannel.MessageCount { get; init; }
		Optional<int> IChannel.MemberCount { get; init; }
		Optional<ThreadMember> IChannel.Member { get; init; }
		Optional<int> IChannel.DefaultAutoArchiveDuration { get; init; }

		public PartialChannel(
			Snowflake id,
			ChannelType type,
			Optional<string> name = default,
			Optional<string> permissions = default,
			Optional<ThreadMetadata> threadMetadata = default,
			Optional<Snowflake?> parentId = default)
		{
			this.Id = id;
			this.Name = name;
			this.Type = type;
			this.Permissions = permissions;
			this.ThreadMetadata = threadMetadata;
			this.ParentId = parentId;
		}
	}

	public record PartialGuildMember : IGuildMember
	{
		[JsonPropertyName("nick"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<string?> Nick { get; init; }

		[JsonPropertyName("roles")]
		public Snowflake[] Roles { get; private init; }

		[JsonPropertyName("joined_at")]
		public DateTime JoinedAt { get; private init; }

		[JsonPropertyName("premium_since"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<DateTime?> PremiumSince { get; init; }

		[JsonPropertyName("pending"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<bool> Pending { get; init; }

		[JsonPropertyName("permissions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<string> Permissions { get; init; }

		Optional<User> IGuildMember.User { get; init; }
		bool IGuildMember.Deaf { get; }
		bool IGuildMember.Mute { get; }

		public PartialGuildMember(
			Snowflake[] roles,
			DateTime joinedAt,
			Optional<string?> nick = default,
			Optional<DateTime?> premiumSince = default,
			Optional<bool> pending = default,
			Optional<string> permissions = default)
		{
			this.Nick = nick;
			this.Roles = roles;
			this.JoinedAt = joinedAt;
			this.PremiumSince = premiumSince;
			this.Pending = pending;
			this.Permissions = permissions;
		}
	}

	public record PartialMessage : Message
	{
		public PartialMessage(
			Snowflake id,
			Snowflake channelId,
			AuthorUser author,
			string content,
			DateTime timestamp,
			DateTime? editedTimestamp,
			bool tts,
			bool mentionEveryone,
			MentionUser[] mentions,
			Snowflake[] mentionRoles,
			Attachment[] attachments,
			Embed[] embeds,
			bool pinned,
			MessageType type,
			Optional<Snowflake> guildId = default,
			Optional<GuildMember> member = default,
			Optional<ChannelMention[]> mentionChannels = default,
			Optional<Reaction[]> reactions = default,
			Optional<dynamic> nonce = default,
			Optional<Snowflake> webhookId = default,
			Optional<MessageActivity> activity = default,
			Optional<Resources.Application.Application> application = default,
			Optional<Snowflake> applicationId = default,
			Optional<MessageReference> messageReference = default,
			Optional<int> flags = default,
			Optional<Message?> referencedMessage = default,
			Optional<Resources.Channel.MessageInteraction> interaction = default,
			Optional<Channel> thread = default,
			Optional<IComponent> components = default,
			Optional<StickerItem[]> stickerItems = default,
			Optional<Sticker[]> stickers = default)
			: base(
				  id,
				  channelId,
				  author,
				  content,
				  timestamp,
				  editedTimestamp,
				  tts,
				  mentionEveryone,
				  mentions,
				  mentionRoles,
				  attachments,
				  embeds,
				  pinned,
				  type,
				  guildId,
				  member,
				  mentionChannels,
				  reactions,
				  nonce,
				  webhookId,
				  activity,
				  application,
				  applicationId,
				  messageReference,
				  flags,
				  referencedMessage,
				  interaction,
				  thread,
				  components,
				  stickerItems,
				  stickers)
		{ }
	}
}

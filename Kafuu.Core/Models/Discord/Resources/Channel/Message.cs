using Kafuu.Core.Models.Discord.Interactions.MessageComponents;
using Kafuu.Core.Models.Discord.Resources.Guild;
using Kafuu.Core.Models.Discord.Resources.Sticker;
using Kafuu.Core.Models.Discord.Resources.User;

namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record Message
{
	private dynamic _nonce;

	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("channel_id")]
	public Snowflake ChannelId { get; private init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; private init; }

	[JsonPropertyName("author")]
	public AuthorUser Author { get; private init; }

	[JsonPropertyName("member"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<GuildMember> Member { get; init; }

	[JsonPropertyName("content")]
	public string Content { get; private init; }

	[JsonPropertyName("timestamp")]
	public DateTime Timestamp { get; private init; }

	[JsonPropertyName("edited_timpestamp")]
	public DateTime? EditedTimestamp { get; private init; }

	[JsonPropertyName("tts")]
	public bool Tts { get; private init; }

	[JsonPropertyName("mention_everyone")]
	public bool MentionEveryone { get; private init; }

	[JsonPropertyName("mentions")]
	public MentionUser[] Mentions { get; private init; }

	[JsonPropertyName("mention_roles")]
	public Snowflake[] MentionRoles { get; private init; }

	[JsonPropertyName("mention_channels"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ChannelMention[]> MentionChannels { get; init; }

	[JsonPropertyName("attachments")]
	public Attachment[] Attachments { get; private init; }

	[JsonPropertyName("embeds")]
	public Embed[] Embeds { get; private init; }

	[JsonPropertyName("reactions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Reaction[]> Reactions { get; init; }

	[JsonPropertyName("nonce"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<dynamic> Nonce
	{
		get => this._nonce;
		init
		{
			if ((dynamic)value is not (int or string))
				throw new ArgumentException("Nonce must be an integer or string.");

			this._nonce = value;
		}
	}

	[JsonPropertyName("pinned")]
	public bool Pinned { get; private init; }

	[JsonPropertyName("webhook_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> WebhookId { get; init; }

	[JsonPropertyName("type")]
	public MessageType Type { get; private init; }

	[JsonPropertyName("activity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<MessageActivity> Activity { get; init; }

	[JsonPropertyName("application"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Application.Application> Application { get; init; }

	[JsonPropertyName("application_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> ApplicationId { get; init; }

	[JsonPropertyName("message_reference"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<MessageReference> MessageReference { get; init; }

	[JsonPropertyName("flags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Flags { get; init; }

	[JsonPropertyName("referenced_message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Message?> ReferencedMessage { get; init; }

	[JsonPropertyName("interaction"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<MessageInteraction> Interaction { get; init; }

	[JsonPropertyName("thread"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Channel> Thread { get; init; }

	[JsonPropertyName("components"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<IComponent> Components { get; init; }

	[JsonPropertyName("sticker_items"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<StickerItem[]> StickerItems { get; init; }

	[JsonPropertyName("stickers"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Sticker.Sticker[]> Stickers { get; init; }

	public Message(
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
	Optional<Application.Application> application = default,
	Optional<Snowflake> applicationId = default,
	Optional<MessageReference> messageReference = default,
	Optional<int> flags = default,
	Optional<Message?> referencedMessage = default,
	Optional<MessageInteraction> interaction = default,
	Optional<Channel> thread = default,
	Optional<IComponent> components = default,
	Optional<StickerItem[]> stickerItems = default,
	Optional<Sticker.Sticker[]> stickers = default)
	{
		this.Id = id;
		this.ChannelId = channelId;
		this.GuildId = guildId;
		this.Author = author;
		this.Member = member;
		this.Content = content;
		this.Timestamp = timestamp;
		this.EditedTimestamp = editedTimestamp;
		this.Tts = tts;
		this.MentionEveryone = mentionEveryone;
		this.Mentions = mentions;
		this.MentionRoles = mentionRoles;
		this.MentionChannels = mentionChannels;
		this.Attachments = attachments;
		this.Embeds = embeds;
		this.Reactions = reactions;
		this.Nonce = nonce;
		this.Pinned = pinned;
		this.WebhookId = webhookId;
		this.Type = type;
		this.Activity = activity;
		this.Application = application;
		this.ApplicationId = applicationId;
		this.MessageReference = messageReference;
		this.Flags = flags;
		this.ReferencedMessage = referencedMessage;
		this.Interaction = interaction;
		this.Thread = thread;
		this.Components = components;
		this.StickerItems = stickerItems;
		this.Stickers = stickers;
	}

	public record AuthorUser : IUser
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

		[JsonPropertyName("discriminator"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<string> Discriminator { get; init; }

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

		string IUser.Discriminator { get; }

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
			Optional<int> publicFlags = default)
		{
			this.Id = id;
			this.Username = username;
			this.Discriminator = discriminator;
			this.Avatar = avatar;
			this.Bot = bot;
			this.System = system;
			this.MfaEnabled = mfaEnabled;
			this.Banner = banner;
			this.AccentColor = accentColor;
			this.Locale = locale;
			this.Verified = verified;
			this.Email = email;
			this.Flags = flags;
			this.PremiumType = premiumType;
			this.PublicFlags = publicFlags;
		}
	}

	public record MentionUser : IUser
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

		[JsonPropertyName("member"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
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
			Optional<GuildMember> member = default)
		{
			this.Id = id;
			this.Username = username;
			this.Discriminator = discriminator;
			this.Avatar = avatar;
			this.Bot = bot;
			this.System = system;
			this.MfaEnabled = mfaEnabled;
			this.Banner = banner;
			this.AccentColor = accentColor;
			this.Locale = locale;
			this.Verified = verified;
			this.Email = email;
			this.Flags = flags;
			this.PremiumType = premiumType;
			this.PublicFlags = publicFlags;
			this.Member = member;
		}
	}
}

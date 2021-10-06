using Kafuu.Core.Models.Discord.Resources.Channel;
using Kafuu.Core.Models.Discord.Resources.Guild;
using Kafuu.Core.Models.Discord.Resources.User;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record Interaction
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("application_id")]
	public Snowflake ApplicationId { get; private init; }

	[JsonPropertyName("type")]
	public InteractionType Type { get; private init; }

	[JsonPropertyName("data"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<IInteractionData> Data { get; init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; init; }

	[JsonPropertyName("channel_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> ChannelId { get; init; }

	[JsonPropertyName("member"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<GuildMember> Member { get; init; }

	[JsonPropertyName("user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<User> User { get; init; }

	[JsonPropertyName("token")]
	public string Token { get; private init; }

	[JsonPropertyName("version")]
	public int Version { get; private init; }

	[JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Message> Message { get; init; }

	public Interaction(
		Snowflake id,
		Snowflake applicationId,
		InteractionType type,
		string token,
		int version,
		Optional<IInteractionData> data = default,
		Optional<Snowflake> guildId = default,
		Optional<Snowflake> channelId = default,
		Optional<GuildMember> member = default,
		Optional<User> user = default,
		Optional<Message> message = default)
	{
		this.Id = id;
		this.ApplicationId = applicationId;
		this.Type = type;
		this.Data = data;
		this.GuildId = guildId;
		this.ChannelId = channelId;
		this.Member = member;
		this.User = user;
		this.Token = token;
		this.Version = version;
		this.Message = message;
	}
}

namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record ThreadMember
{
	[JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> Id { get; init; }

	[JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> UserId { get; init; }

	[JsonPropertyName("join_timestamp")]
	public DateTime JoinTimestamp { get; private init; }

	[JsonPropertyName("flags")]
	public int Flags { get; private init; }

	public ThreadMember(
		DateTime joinTimestamp,
		int flags,
		Optional<Snowflake> id = default,
		Optional<Snowflake> userId = default)
	{
		this.Id = id;
		this.UserId = userId;
		this.JoinTimestamp = joinTimestamp;
		this.Flags = flags;
	}
}

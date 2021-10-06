namespace Kafuu.Core.Models.Discord.Resources.Channel;

public struct Overwrite
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("type")]
	public int Type { get; private init; }

	[JsonPropertyName("allow")]
	public string Allow { get; private init; }

	[JsonPropertyName("deny")]
	public string Deny { get; private init; }

	public Overwrite(Snowflake id, int type, string allow, string deny)
	{
		this.Id = id;
		this.Type = type;
		this.Allow = allow;
		this.Deny = deny;
	}
}

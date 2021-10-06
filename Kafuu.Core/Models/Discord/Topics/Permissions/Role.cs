namespace Kafuu.Core.Models.Discord.Topics.Permissions;

public record Role
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("color")]
	public int Color { get; private init; }

	[JsonPropertyName("hoist")]
	public bool Hoist { get; private init; }

	[JsonPropertyName("position")]
	public int Position { get; private init; }

	[JsonPropertyName("permissions")]
	public string Permissions { get; private init; }

	[JsonPropertyName("managed")]
	public bool Managed { get; private init; }

	[JsonPropertyName("mentionable")]
	public bool Mentionable { get; private init; }

	[JsonPropertyName("tags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<RoleTags> Tags { get; init; }

	public Role(
		Snowflake id,
		string name,
		int color,
		bool hoist,
		int position,
		string permissions,
		bool managed,
		bool mentionable,
		Optional<RoleTags> tags = default)
	{
		this.Id = id;
		this.Name = name;
		this.Color = color;
		this.Hoist = hoist;
		this.Position = position;
		this.Permissions = permissions;
		this.Managed = managed;
		this.Mentionable = mentionable;
		this.Tags = tags;
	}
}

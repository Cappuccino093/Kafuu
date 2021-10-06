using Kafuu.Core.Models.Discord.Topics.Permissions;

namespace Kafuu.Core.Models.Discord.Resources.Emoji;

public record Emoji : IEmoji
{
	[JsonPropertyName("id")]
	public Snowflake? Id { get; private init; }

	[JsonPropertyName("name")]
	public string? Name { get; private init; }

	[JsonPropertyName("roles"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Role> Roles { get; init; }

	[JsonPropertyName("user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<User.User> User { get; init; }

	[JsonPropertyName("require_colons"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> RequireColons { get; init; }

	[JsonPropertyName("managed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Managed { get; init; }

	[JsonPropertyName("animated"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Animated { get; init; }

	[JsonPropertyName("available"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Available { get; init; }

	public Emoji(
		Snowflake? id,
		string? name,
		Optional<Role> roles = default,
		Optional<User.User> user = default,
		Optional<bool> requireColons = default,
		Optional<bool> managed = default,
		Optional<bool> animated = default,
		Optional<bool> available = default)
	{
		this.Id = id;
		this.Name = name;
		this.Roles = roles;
		this.User = user;
		this.RequireColons = requireColons;
		this.Managed = managed;
		this.Animated = animated;
		this.Available = available;
	}
}

using Kafuu.Core.Models.Discord.Topics.Permissions;

namespace Kafuu.Core.Models.Discord.Resources.Emoji;

internal interface IEmoji
{
	public Snowflake? Id { get; }
	public string? Name { get; }
	public Optional<Role> Roles { get; init; }
	public Optional<User.User> User { get; init; }
	public Optional<bool> RequireColons { get; init; }
	public Optional<bool> Managed { get; init; }
	public Optional<bool> Animated { get; init; }
	public Optional<bool> Available { get; init; }
}

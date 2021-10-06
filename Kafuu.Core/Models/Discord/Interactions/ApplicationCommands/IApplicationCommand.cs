namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

public interface IApplicationCommand
{
	Snowflake Id { get; }
	Optional<ApplicationCommandType> Type { get; init; }
	Snowflake ApplicationId { get; }
	Optional<Snowflake> GuildId { get; init; }
	string Name { get; }
	string Description { get; }
	Optional<ApplicationCommandOption[]> Options { get; init; }
	Optional<bool> DefaultPermission { get; init; }
	Snowflake Version { get; }
}

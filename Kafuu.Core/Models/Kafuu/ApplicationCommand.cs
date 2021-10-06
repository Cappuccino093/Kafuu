using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;
using Kafuu.Core.Models.Discord.Resources.Channel;

namespace Kafuu.Core.Models.Kafuu;

public abstract class ApplicationCommand : IApplicationCommand
{
	public static explicit operator CreateApplicationCommand(ApplicationCommand applicationCommand) =>
		new(applicationCommand.Name, applicationCommand.Description, applicationCommand.Options, applicationCommand.DefaultPermission, applicationCommand.Type);

	public Snowflake? Id { get; private init; }
	public Optional<ApplicationCommandType> Type { get; init; }
	public Snowflake ApplicationId { get; private init; }
	public Optional<Snowflake> GuildId { get; init; }
	public string Name { get; private init; }
	public string Description { get; private init; }
	public Optional<ApplicationCommandOption[]> Options { get; init; }
	public Optional<bool> DefaultPermission { get; init; }
	public Snowflake? Version { get; private init; }

	Snowflake IApplicationCommand.Id { get; }
	Snowflake IApplicationCommand.Version { get; }

	public ApplicationCommand(
		string name,
		string description,
		Snowflake? id = null,
		Optional<ApplicationCommandType> type = default,
		Optional<Snowflake> guildId = default,
		Optional<ApplicationCommandOption[]> options = default,
		Optional<bool> defaultPermission = default,
		Snowflake? version = null)
	{
		this.Id = id;
		this.Type = type;
		this.ApplicationId = Core.Kafuu.Application.General.ApplicationId;
		this.GuildId = guildId;
		this.Name = name;
		this.Description = description;
		this.Options = options;
		this.DefaultPermission = defaultPermission;
		this.Version = version;
	}

	public abstract InteractionCallbackData InteractionCallback();
}

namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

public record CreateApplicationCommand : IApplicationCommand
{
	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("description")]
	public string Description { get; private init; }

	[JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandOption[]> Options { get; init; }

	[JsonPropertyName("default_premission"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> DefaultPermission { get; init; }

	[JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandType> Type { get; init; }

	Snowflake IApplicationCommand.Id { get; }
	Snowflake IApplicationCommand.ApplicationId { get; }
	Optional<Snowflake> IApplicationCommand.GuildId { get; init; }
	Snowflake IApplicationCommand.Version { get; }

	public CreateApplicationCommand(
		string name,
		string description,
		Optional<ApplicationCommandOption[]> options = default,
		Optional<bool> defaultPermission = default,
		Optional<ApplicationCommandType> type = default)
	{
		this.Name = name;
		this.Description = description;
		this.Options = options;
		this.DefaultPermission = defaultPermission;
		this.Type = type;
	}
}

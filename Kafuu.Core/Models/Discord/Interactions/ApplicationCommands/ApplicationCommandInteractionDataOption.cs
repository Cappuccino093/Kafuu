namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

public record ApplicationCommandInteractionDataOption
{
	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("type")]
	public ApplicationCommandOptionType Type { get; private init; }

	[JsonPropertyName("value"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<dynamic> Value { get; init; }

	[JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandInteractionDataOption[]> Options { get; init; }

	public ApplicationCommandInteractionDataOption(
		string name,
		ApplicationCommandOptionType type,
		Optional<dynamic> value = default,
		Optional<ApplicationCommandInteractionDataOption[]> options = default)
	{
		this.Name = name;
		this.Type = type;
		this.Value = value;
		this.Options = options;
	}
}

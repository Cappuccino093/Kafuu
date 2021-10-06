using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Interactions.MessageComponents;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record ApplicationCommandInteractionData : IInteractionData
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("type")]
	public ApplicationCommandType Type { get; private init; }

	[JsonPropertyName("resolved"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ResolvedData> Resolved { get; init; }

	[JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandInteractionDataOption[]> Options { get; init; }

	Optional<string> IInteractionData.CustomId { get; init; }
	Optional<ComponentType> IInteractionData.ComponentType { get; init; }
	Optional<SelectOption[]> IInteractionData.Values { get; init; }
	Optional<Snowflake> IInteractionData.TargetId { get; init; }

	public ApplicationCommandInteractionData(
		Snowflake id,
		string name,
		ApplicationCommandType type,
		Optional<ResolvedData> resolved = default,
		Optional<ApplicationCommandInteractionDataOption[]> options = default)
	{
		this.Id = id;
		this.Name = name;
		this.Type = type;
		this.Resolved = resolved;
		this.Options = options;
	}
}

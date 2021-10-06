using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Interactions.MessageComponents;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record ComponentInteractionData : IInteractionData
{
	private Optional<SelectOption> _values;

	[JsonPropertyName("custom_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> CustomId { get; init; }

	[JsonPropertyName("component_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ComponentType> ComponentType { get; init; }

	[JsonPropertyName("values"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<SelectOption> Values
	{
		get => this._values;
		init
		{
			if (this.ComponentType.HasValue && this.ComponentType != MessageComponents.ComponentType.SelectMenu)
				throw new ArgumentException("Values can't be set if the Component Type is not Select Menu");

			this._values = value;
		}
	}

	Snowflake IInteractionData.Id{ get; }
	string IInteractionData.Name { get; }
	ApplicationCommandType IInteractionData.Type { get; }
	Optional<ResolvedData> IInteractionData.Resolved { get; init; }
	Optional<ApplicationCommandInteractionDataOption[]> IInteractionData.Options { get; init; }
	Optional<SelectOption[]> IInteractionData.Values { get; init; }
	Optional<Snowflake> IInteractionData.TargetId { get; init; }

	public ComponentInteractionData(
		Optional<string> customId = default,
		Optional<ComponentType> componentType = default,
		Optional<SelectOption> values = default)
	{
		this.CustomId = customId;
		this.ComponentType = componentType;
		this.Values = values;
	}
}

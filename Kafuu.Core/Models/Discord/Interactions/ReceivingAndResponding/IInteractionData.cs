using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Interactions.MessageComponents;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

[JsonConverter(typeof(IInteractionDataConverter))]
public interface IInteractionData
{
	public Snowflake Id { get; }
	public string Name { get; }
	public ApplicationCommandType Type { get; }
	public Optional<ResolvedData> Resolved { get; init; }
	public Optional<ApplicationCommandInteractionDataOption[]> Options { get; init; }
	public Optional<string> CustomId { get; init; }
	public Optional<ComponentType> ComponentType { get; init; }
	public Optional<SelectOption[]> Values { get; init; }
	public Optional<Snowflake> TargetId { get; init; }
}

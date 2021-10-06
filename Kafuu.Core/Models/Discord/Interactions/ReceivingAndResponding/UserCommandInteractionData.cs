using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Interactions.MessageComponents;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record UserCommandInteractionData : ApplicationCommandInteractionData
{
	[JsonPropertyName("target_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> TargetId { get; init; }

	public UserCommandInteractionData(
		Snowflake id,
		string name,
		ApplicationCommandType type,
		Optional<Snowflake> targetId = default,
		Optional<ResolvedData> resolved = default,
		Optional<ApplicationCommandInteractionDataOption[]> options = default)
		: base(id, name, type, resolved, options)
	=> this.TargetId = targetId;
}

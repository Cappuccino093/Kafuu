using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record MessageCommandInteractionData : ApplicationCommandInteractionData
{
	[JsonPropertyName("target_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> TargetId { get; init; }

	public MessageCommandInteractionData(
		Snowflake id,
		string name,
		ApplicationCommandType type,
		Optional<Snowflake> targetId = default,
		Optional<ResolvedData> resolved = default,
		Optional<ApplicationCommandInteractionDataOption[]> options = default)
		: base(id, name, type, resolved, options)
	=> this.TargetId = targetId;
	

}

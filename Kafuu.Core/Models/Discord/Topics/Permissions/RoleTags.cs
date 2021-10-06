namespace Kafuu.Core.Models.Discord.Topics.Permissions;

public record RoleTags
{
	[JsonPropertyName("bot_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> BotId { get; init; }

	[JsonPropertyName("integration_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> IntegrationId { get; init; }

	[JsonPropertyName("premium_subscriber"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> PremiumSubscriber { get; init; }

	public RoleTags(
		Optional<Snowflake> botId = default,
		Optional<Snowflake> integrationId = default,
		Optional<bool> premiumSubscriber = default)
	{
		this.BotId = botId;
		this.IntegrationId = integrationId;
		this.PremiumSubscriber = premiumSubscriber;
	}
}

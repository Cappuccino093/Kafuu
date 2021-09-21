namespace DiscordApi.Topics.Permissions;

public record RoleTags
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Snowflake? BotId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Snowflake? IntegrationId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Snowflake? PremiumSubscriber { get; init; }

    public RoleTags(
        Snowflake? botId = null,
        Snowflake? integrationId = null,
        Snowflake? premiumSubscriber = null) =>
        (BotId, IntegrationId, PremiumSubscriber) = (botId, integrationId, premiumSubscriber);
}

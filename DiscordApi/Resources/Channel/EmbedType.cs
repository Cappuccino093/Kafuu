namespace DiscordApi.Resources.Channel;

[JsonConverter(typeof(SnakeCaseNamingPolicyJsonStringEnumConverter))]
public enum EmbedType
{
    Rich,
    Image,
    Video,
    Gifv,
    Article,
    Link
}

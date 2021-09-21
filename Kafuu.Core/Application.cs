using System.Text.Json.Serialization;

namespace Kafuu.Core;

public struct Application
{
    public GeneralConfiguration General { get; }
    public OAuth2Configuration OAuth2 { get; }
    public BotConfiguration Bot { get; }

    [JsonConstructor]
    public Application(
        GeneralConfiguration general,
        OAuth2Configuration oAuth2,
        BotConfiguration bot) =>
        (General, OAuth2, Bot) =
        (general, oAuth2, bot);

    public struct GeneralConfiguration
    {
        public Snowflake ApplicationId { get; }
        public string PublicKey { get; }

        [JsonConstructor]
        public GeneralConfiguration(Snowflake applicationId, string publicKey) =>
            (ApplicationId, PublicKey) = (applicationId, publicKey);
    }

    public struct OAuth2Configuration
    {
        public Snowflake ClientId { get; }
        public string ClientSecret { get; }

        [JsonConstructor]
        public OAuth2Configuration(Snowflake clientId, string clientSecret) =>
            (ClientId, ClientSecret) = (clientId, clientSecret);
    }

    public struct BotConfiguration
    {
        public string Token { get; }

        [JsonConstructor]
        public BotConfiguration(string token) =>
            Token = token;
    }
}

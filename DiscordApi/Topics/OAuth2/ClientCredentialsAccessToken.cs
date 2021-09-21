namespace DiscordApi.Topics.OAuth2;

public record ClientCredentialsAccessToken
{
    public string AccessToken { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AuthorizationTokenType TokenType { get; }

    public int ExpiresIn { get; }
    public string Scope { get; }

    public ClientCredentialsAccessToken(string accessToken, AuthorizationTokenType tokenType, int expiresIn, string scope) =>
        (AccessToken, TokenType, ExpiresIn, Scope) = (accessToken, tokenType, expiresIn, scope);
}

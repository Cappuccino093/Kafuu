using DiscordApi.Topics.OAuth2;

namespace Kafuu.Core.Core.Topics.OAuth2
{
    public static class OAuth2
    {
        public static async Task<ClientCredentialsAccessToken> GetClientCredentialsAccessToken()
        {
            ClientCredentialsAccessToken clientCredentialsAccessToken =
                await DiscordApi.Topics.OAuth2.OAuth2.ClientCredentialsGrant(
                    Kafuu.OAuth2Scopes,
                    Kafuu.Application.OAuth2.ClientId,
                    Kafuu.Application.OAuth2.ClientSecret,
                    Kafuu.ApiVersion);

            return clientCredentialsAccessToken;
        }

        public static async Task<AuthorizationToken> GetBearerAuthorizationToken()
        {
            ClientCredentialsAccessToken clientCredentialsAccessToken =
                await DiscordApi.Topics.OAuth2.OAuth2.ClientCredentialsGrant(
                    Kafuu.OAuth2Scopes,
                    Kafuu.Application.OAuth2.ClientId,
                    Kafuu.Application.OAuth2.ClientSecret,
                    Kafuu.ApiVersion);

            AuthorizationToken authorizationToken = new(
                clientCredentialsAccessToken.TokenType,
                clientCredentialsAccessToken.AccessToken);

            return authorizationToken;
        }

        public static AuthorizationToken GetBearerAuthorizationToken(ClientCredentialsAccessToken clientCredentialsAccessToken)
        {
            AuthorizationToken authorizationToken = new(
                clientCredentialsAccessToken.TokenType,
                clientCredentialsAccessToken.AccessToken);

            return authorizationToken;
        }
    }
}

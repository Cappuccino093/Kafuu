using System.Collections.Generic;

namespace DiscordApi.Topics.OAuth2
{
    public static class OAuth2
    {
        public static Uri AuthorizationUrl { get; } = new("https://discord.com/api/oauth2/authorize");
        public static Uri TokenUrl { get; } = new("https://discord.com/api/oauth2/token");
        public static Uri TokenRevocationUrl { get; } = new("https://discord.com/api/oauth2/token/revoke");

        public static async Task<ClientCredentialsAccessToken> ClientCredentialsGrant(
            OAuth2Scope[] oAuth2Scopes,
            Snowflake clientId,
            string clientSecret,
            ApiVersion? apiVersion = null)
        {
            // New request
            HttpRequestMessage httpRequestMessage = new(
                HttpMethod.Post,
                $"/{apiVersion ?? DiscordApi.ApiVersion}{TokenUrl.ToString()[DiscordApi.BaseURL.ToString().Length..]}");

            // Request headers
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId.Value}:{clientSecret}")));
            
            // Request body
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            httpRequestMessage.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "scope", $"{string.Join(' ', oAuth2Scopes.Select(oAuth2Scope => DotCaseNamingPolicy.ConvertToDotCase(oAuth2Scope.ToString())))}" }
            });

            // Response
            HttpResponseMessage httpResponseMessage = await DiscordApi.HttpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
                return JsonSerializer.Deserialize<ClientCredentialsAccessToken>(await httpResponseMessage.Content.ReadAsStringAsync());
            else
                throw new Exception($"{httpResponseMessage.StatusCode}: {await httpResponseMessage.Content.ReadAsStringAsync()}");
        }
    }
}

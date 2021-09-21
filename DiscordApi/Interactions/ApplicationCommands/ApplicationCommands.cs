namespace DiscordApi.Interactions.ApplicationCommands;

public static class ApplicationCommands
{
    public static async Task<ApplicationCommand[]> BulkOverwriteGlobalApplicationCommands(
        CreateApplicationCommand[] applicationCommands,
        Snowflake applicationId,
        AuthorizationToken authorizationToken,
        ApiVersion? apiVersion = null)
    {
        // New request
        HttpRequestMessage httpRequestMessage = new(
            HttpMethod.Put,
            $"/{apiVersion ?? DiscordApi.ApiVersion}/applications/{applicationId.Value}/commands");

        // Request headers
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Authorization", $"{authorizationToken.TokenType} {authorizationToken.Token}");

        // Request body
        httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(applicationCommands, DiscordApi.JsonSerializerOptions));

        // Response
        HttpResponseMessage httpResponseMessage = await DiscordApi.HttpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<ApplicationCommand[]>(await httpResponseMessage.Content.ReadAsStringAsync(), DiscordApi.JsonSerializerOptions);
        else
            throw new Exception($"{httpResponseMessage.StatusCode}: {await httpResponseMessage.Content.ReadAsStringAsync()}");
    }

    public static async Task<ApplicationCommand[]> GetGlobalApplicationCommands(
        Snowflake applicationId,
        AuthorizationToken authorizationToken,
        ApiVersion? apiVersion = null)
    {
        // New request
        HttpRequestMessage httpRequestMessage = new(
            HttpMethod.Get,
            $"/{apiVersion ?? DiscordApi.ApiVersion}/applications/{applicationId.Value}/commands");

        // Request headers
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Authorization", $"{authorizationToken.TokenType} {authorizationToken.Token}");

        // Response
        HttpResponseMessage httpResponseMessage = await DiscordApi.HttpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<ApplicationCommand[]>(await httpResponseMessage.Content.ReadAsStringAsync(), DiscordApi.JsonSerializerOptions);
        else
            throw new Exception($"{httpResponseMessage.StatusCode}: {await httpResponseMessage.Content.ReadAsStringAsync()}");
    }

    public record CreateApplicationCommand : ApplicationCommand
    {
#pragma warning disable IDE0051
        private new readonly Snowflake Id;
        private new readonly Snowflake ApplicationId;
        private new readonly Snowflake Version;
        private new readonly Snowflake GuildId;
#pragma warning restore IDE0051

        public CreateApplicationCommand(
            string name,
            string description,
            Optional<ApplicationCommandType> type = default,
            Optional<ApplicationCommandOption[]> options = default,
            Optional<bool> defaultPermission = default) :
            base(default, default, name, description, default, type, default, options, defaultPermission)
        { }
    }
}

global using System;
global using System.Linq;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;

namespace DiscordApi;

public static class DiscordApi
{
    public static HttpClient HttpClient { get; } = new();
    public static Uri BaseURL { get; } = new("https://discord.com/api");
    public static ApiVersion ApiVersion { get; } = ApiVersion.v6;
    public static JsonSerializerOptions JsonSerializerOptions { get; } = new();

    static DiscordApi()
    {
        HttpClient.BaseAddress = BaseURL;
        HttpClient.DefaultRequestHeaders.Clear();

        JsonSerializerOptions.Converters.Add(new ColorConverter());
        JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
    }
}

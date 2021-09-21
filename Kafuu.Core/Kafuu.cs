global using DiscordApi;
global using System.Collections.Generic;
global using System.Drawing;
global using System.Text.Json;
global using System.Threading.Tasks;
using DiscordApi.Topics.OAuth2;
using System.IO;

namespace Kafuu.Core;

public static class Kafuu
{
    public static Application Application { get; } = JsonSerializer.Deserialize<Application>(File.ReadAllText("Configuration.json"));
    public static ApiVersion ApiVersion { get; } = ApiVersion.v9;
    public static OAuth2Scope[] OAuth2Scopes { get; } = new[] { OAuth2Scope.ApplicationsCommandsUpdate };
    public static Color Color { get; } = Color.MediumBlue;
}

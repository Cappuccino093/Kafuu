namespace DiscordApi;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => ConvertToSnakeCase(name);

    public static string ConvertToSnakeCase(string @string) =>
        string.Concat(@string.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
}

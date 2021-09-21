namespace DiscordApi
{
    public class DotCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => ConvertToDotCase(name);

        public static string ConvertToDotCase(string @string) =>
            string.Concat(@string.Select((x, i) => i > 0 && char.IsUpper(x) ? "." + x.ToString() : x.ToString())).ToLower();
    }
}

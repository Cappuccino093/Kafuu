namespace DiscordApi.Resources.Channel;

public record EmbedProvider
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> Url { get; init; }

    public EmbedProvider(
        Optional<string> name,
        Optional<Uri> url) =>
        (Name, Url) = (name, url);
}

namespace DiscordApi.Resources.Channel;

public record EmbedVideo
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> Url { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> ProxyUrl { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Height { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int> Width { get; init; }

    public EmbedVideo(
        Optional<Uri> url = default,
        Optional<Uri> proxyUrl = default,
        Optional<int> height = default,
        Optional<int> width = default) =>
        (Url, ProxyUrl, Height, Width) =
        (url, proxyUrl, height, width);
}

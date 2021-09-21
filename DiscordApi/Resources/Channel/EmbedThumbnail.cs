namespace DiscordApi.Resources.Channel;

public record EmbedThumbnail
{
    public Uri Url { get; }
    public Optional<Uri> ProxyUrl { get; init; }
    public Optional<int> Height { get; init; }
    public Optional<int> Width { get; init; }

    public EmbedThumbnail(
        Uri url,
        Optional<Uri> proxyUrl,
        Optional<int> height,
        Optional<int> width) =>
        (Url, ProxyUrl, Height, Width) =
        (url, proxyUrl, height, width);
}

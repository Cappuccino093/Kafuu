namespace DiscordApi.Resources.Channel;

public record Attachment
{
    public Snowflake Id { get; }
    public string Filename { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> ContentType { get; init; }

    public int Size { get; }
    public Uri Url { get; }
    public Uri ProxyUrl { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int?> Height { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<int?> Width { get; init; }

    public Attachment(
        Snowflake id,
        string filename,
        int size,
        Uri url,
        Uri proxyUrl,
        Optional<string> contentType = default,
        Optional<int?> height = default,
        Optional<int?> width = default) =>
        (Id, Filename, ContentType, Size, Url, ProxyUrl, Height, Width) =
        (id, filename, contentType, size, url, proxyUrl, height, width);
}

namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record Attachment
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("filename")]
	public string Filename { get; private init; }

	[JsonPropertyName("content_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> ContentType { get; init; }

	[JsonPropertyName("size")]
	public int Size { get; private init; }

	[JsonPropertyName("url")]
	public Uri Url { get; private init; }

	[JsonPropertyName("proxy_url")]
	public Uri ProxyUrl { get; private init; }

	[JsonPropertyName("height"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int?> Height { get; init; }

	[JsonPropertyName("width"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int?> Width { get; init; }

	public Attachment(
		Snowflake id,
		string filename,
		int size,
		Uri url,
		Uri proxyUrl,
		Optional<string> contentType = default,
		Optional<int?> height = default,
		Optional<int?> width = default)
	{
		this.Id = id;
		this.Filename = filename;
		this.ContentType = contentType;
		this.Size = size;
		this.Url = url;
		this.ProxyUrl = proxyUrl;
		this.Height = height;
		this.Width = width;
	}
}

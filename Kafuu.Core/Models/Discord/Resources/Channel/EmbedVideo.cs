namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record EmbedVideo
{
	[JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> Url { get; init; }

	[JsonPropertyName("proxy_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> ProxyUrl { get; init; }

	[JsonPropertyName("height"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Height { get; init; }

	[JsonPropertyName("width"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Width { get; init; }

	public EmbedVideo(
		Optional<Uri> url = default,
		Optional<Uri> proxyUrl = default,
		Optional<int> height = default,
		Optional<int> width = default)
	{
		this.Url = url;
		this.ProxyUrl = proxyUrl;
		this.Height = height;
		this.Width = width;
	}
}

namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record EmbedProvider
{
	[JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Name { get; init; }

	[JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> Url { get; init; }

	public EmbedProvider(
		Optional<string> name = default,
		Optional<Uri> url = default)
	{
		this.Name = name;
		this.Url = url;
	}
}

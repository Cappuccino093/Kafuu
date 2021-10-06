namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record EmbedAuthor
{
	private string _name;

	[JsonPropertyName("name")]
	public string Name
	{
		get => this._name;
		private init
		{
			if (!(value.Length <= 256))
				throw new ArgumentException("Value of property Name must be a string with maximum 256 characters.");

			this._name = value;
		}
	}

	[JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> Url { get; init; }

	[JsonPropertyName("icon_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> IconUrl { get; init; }

	[JsonPropertyName("proxy_icon_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> ProxyIconUrl { get; init; }

	public EmbedAuthor(
		string name,
		Optional<Uri> url = default,
		Optional<Uri> iconUrl = default,
		Optional<Uri> proxyIconUrl = default)
	{
		this.Name = name;
		this.Url = url;
		this.IconUrl = iconUrl;
		this.ProxyIconUrl = proxyIconUrl;
	}
}

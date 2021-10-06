namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record EmbedFooter
{
	private string _text;

	[JsonPropertyName("text")]
	public string Text
	{
		get => this._text;
		private init
		{
			if (!(value.Length <= 2048))
				throw new ArgumentException("Text must contain a maximum of 2048 characters.");

			this._text = value;
		}
	}

	[JsonPropertyName("icon_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> IconUrl { get; init; }

	[JsonPropertyName("proxy_icon_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> ProxyIconUrl { get; init; }

	public EmbedFooter(
		string text,
		Optional<Uri> iconUrl = default,
		Optional<Uri> proxyIconUrl = default)
	{
		this.Text = text;
		this.IconUrl = iconUrl;
		this.ProxyIconUrl = proxyIconUrl;
	}
}

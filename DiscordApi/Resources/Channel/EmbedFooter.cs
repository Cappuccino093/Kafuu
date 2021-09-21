namespace DiscordApi.Resources.Channel;

public record EmbedFooter
{
    private string _text;

    public string Text
    {
        get => _text;
        private init
        {
            if (!(value.Length <= 2048))
                throw new ArgumentException("Text must contain a maximum of 2048 characters.");

            _text = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> IconUrl { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> ProxyIconUrl { get; init; }

    public EmbedFooter(
        string text,
        Optional<Uri> iconUrl = default,
        Optional<Uri> proxyIconUrl = default) =>
        (Text, IconUrl, ProxyIconUrl) = (text, iconUrl, proxyIconUrl);
}

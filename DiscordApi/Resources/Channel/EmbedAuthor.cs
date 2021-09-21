namespace DiscordApi.Resources.Channel;

public record EmbedAuthor
{
    private string _name;

    public string Name
    {
        get => _name;
        private init
        {
            if (!(value.Length <= 256))
                throw new ArgumentException("Value of property Name must be a string with maximum 256 characters.");

            _name = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> Url { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> IconUrl { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> ProxyIconUrl { get; init; }

    public EmbedAuthor(
        string name,
        Optional<Uri> url,
        Optional<Uri> iconUrl,
        Optional<Uri> proxyIconUrl)
    {
        Name = name;
        Url = url;
        IconUrl = iconUrl;
        ProxyIconUrl = proxyIconUrl;
    }
}

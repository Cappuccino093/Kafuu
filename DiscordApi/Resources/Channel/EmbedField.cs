namespace DiscordApi.Resources.Channel;

public record EmbedField
{
    private string _name;
    private string _value;

    public string Name
    {
        get => _name;
        private init
        {
            if (!(value.Length <= 256))
                throw new ArgumentException("Name must contain a maximum of 256 characters.");

            _name = value;
        }
    }

    public string Value
    {
        get => _value;
        private init
        {
            if (!(value.Length <= 1024))
                throw new ArgumentException("Value must contain a maximum of 1024 characters.");

            _value = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Inline { get; init; }

    public EmbedField(
        string name,
        string value,
        Optional<bool> inline) =>
        (Name, Value, Inline) =
        (name, value, inline);
}

namespace DiscordApi.Interactions.ApplicationCommands;

public record ApplicationCommandOptionChoice
{
    private string _name;
    private object _value;

    public string Name
    {
        get => _name;
        private init
        {
            if (!(value.Length >= 0 && value.Length <= 100))
                throw new ArgumentException("Value must be a 1-100 character string.");

            _name = value;
        }
    }

    public object Value
    {
        get => _value;
        private init
        {
            if (!(value is string || value is int || value is double))
                throw new ArgumentException("Value must be of type string, int or double.");

            if (value is string @string && (!(@string.Length >= 0 && @string.Length <= 100)))
                throw new ArgumentException("Value of type string must be a 1-100 character string.");

            _value = value;
        }
    }

    public ApplicationCommandOptionChoice(string name, object value) =>
        (Name, Value) = (name, value);
}

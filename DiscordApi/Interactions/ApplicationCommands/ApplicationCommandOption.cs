using System.Text.RegularExpressions;

namespace DiscordApi.Interactions.ApplicationCommands;

public record ApplicationCommandOption
{
    private string _name;
    private string _description;
    private Optional<ApplicationCommandOptionChoice[]> _choices;
    private Optional<ApplicationCommandOption[]> _options;

    public ApplicationCommandOptionType Type { get; }

    public string Name
    {
        get => _name;
        private init
        {
            if (!(new Regex(@"^[\w-]{1,32}$").IsMatch(value)))
                throw new ArgumentException("Value must be a 1-32 lowercase character name matching ^[\\w-]{1,32}$");

            _name = value;
        }
    }

    public string Description
    {
        get => _description;
        private init
        {
            if (!(value.Length >= 0 && value.Length <= 100))
                throw new ArgumentException("Value must be a 1-100 character description");

            _description = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Required { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ApplicationCommandOptionChoice[]> Choices
    {
        get => _choices;
        init
        {
            if (((ApplicationCommandOptionChoice[])value).Length > 25)
                throw new ArgumentException("Value must be an array of maximum 25 Application Command Option Choice.");

            _choices = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ApplicationCommandOption[]> Options
    {
        get => _options;
        init
        {
            if (((ApplicationCommandOption[])value).Length > 25)
                throw new ArgumentException("Application Command Options must be an array of maximum 25 ApplicationCommandOption.");

            Array.Sort((ApplicationCommandOption[])value, (option1, option2) => option2.Required.CompareTo(option1.Required));
            Array.Reverse((ApplicationCommandOption[])value);

            _options = value;
        }
    }

    public ApplicationCommandOption(
        ApplicationCommandOptionType type,
        string name,
        string description,
        Optional<bool> required = default,
        Optional<ApplicationCommandOptionChoice[]> choices = default,
        Optional<ApplicationCommandOption[]> options = default) =>
        (Type, Name, Description, Required, Choices, Options) =
        (type, name, description, required, choices, options);
}

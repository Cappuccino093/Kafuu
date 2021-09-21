using System.Text.RegularExpressions;

namespace DiscordApi.Interactions.ApplicationCommands;

public record ApplicationCommand
{
    private string _name;
    private string _description;
    private Optional<ApplicationCommandOption[]> _options;

    public Snowflake Id { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ApplicationCommandType> Type { get; init; }

    public Snowflake ApplicationId { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Snowflake> GuildId { get; init; }

    public string Name
    {
        get => _name;
        private init
        {
            if (Type != default(Optional<ApplicationCommandType>) && Type == ApplicationCommandType.ChatInput && !(new Regex(@"^[\w-]{1,32}$").IsMatch(value)))
                throw new ArgumentException("Name of Chat Input Application Commands must be a 1-32 lowercase character name matching ^[\\w-]{1,32}$");

            _name = value;
        }
    }

    public string Description
    {
        get => _description;
        private init
        {
            if (!(value.Length >= 1 && value.Length <= 100))
                throw new ArgumentException("Value must be a 1-100 character string.");

            if (Type != default(Optional<ApplicationCommandType>) && Type != ApplicationCommandType.ChatInput && !string.IsNullOrEmpty(value))
                throw new ArgumentException("Value of Commands of type User and Message must be empty strings.");

            _description = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ApplicationCommandOption[]> Options
    {
        get => _options;
        init
        {
            if (value != default(Optional<ApplicationCommandOption[]>))
            {
                if (((ApplicationCommandOption[])value).Length > 0 && Type != ApplicationCommandType.ChatInput)
                    throw new ArgumentException("Application Command Options can only be used on an Application Command with type ChatInput.");

                if (((ApplicationCommandOption[])value).Length > 25)
                    throw new ArgumentException("Application Command Options must be an array of maximum 25 ApplicationCommandOption.");

                Array.Sort((ApplicationCommandOption[])value, (option1, option2) => option2.Required.CompareTo(option1.Required));
            }
            _options = value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> DefaultPermission { get; init; }

    public Snowflake Version { get; }

    public ApplicationCommand(
        Snowflake id,
        Snowflake applicationId,
        string name,
        string description,
        Snowflake version,
        Optional<ApplicationCommandType> type = default,
        Optional<Snowflake> guildId = default,
        Optional<ApplicationCommandOption[]> options = default,
        Optional<bool> defaultPermission = default) =>
        (Id, Type, ApplicationId, GuildId, Name, Description, Version, Options, DefaultPermission) =
        (id, type, applicationId, guildId, name, description, version, options, defaultPermission);
}

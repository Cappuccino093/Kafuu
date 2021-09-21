namespace DiscordApi.Interactions.ApplicationCommands;

public record ApplicationCommandInteractionDataOption
{
    public string Name { get; }
    public ApplicationCommandOptionType Type { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<object> Value { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<ApplicationCommandInteractionDataOption[]> Options { get; init; }

    public ApplicationCommandInteractionDataOption(
        string name,
        ApplicationCommandOptionType type,
        Optional<object> value = default,
        Optional<ApplicationCommandInteractionDataOption[]> options = default) =>
        (Name, Type, Value, Options) =
        (name, type, value, options);

}

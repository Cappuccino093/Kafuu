namespace DiscordApi.Interactions.ApplicationCommands;

public enum ApplicationCommandOptionType
{
    SubCommand = 1,
    SubCommandGroup,
    String,
    Integer,
    Boolean,
    User,
    Channel,
    Role,
    Mentionable,
    Number
}

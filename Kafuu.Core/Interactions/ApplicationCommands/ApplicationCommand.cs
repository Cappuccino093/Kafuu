using DiscordApi.Interactions.ApplicationCommands;

namespace Kafuu.Core.Interactions.ApplicationCommands
{
    public abstract record ApplicationCommand : DiscordApi.Interactions.ApplicationCommands.ApplicationCommands.CreateApplicationCommand
    {
        public ApplicationCommand(
            string name,
            string description = "No description was provided.",
            Optional<ApplicationCommandOption[]> options = default,
            Optional<bool> defaultPermission = default,
            Optional<ApplicationCommandType> type = default)
            : base(name, description, type, options, defaultPermission)
        { }

        public abstract void Execute();
    }
}

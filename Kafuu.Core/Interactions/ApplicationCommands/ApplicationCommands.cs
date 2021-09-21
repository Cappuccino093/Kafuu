using System.Collections.Generic;

namespace Kafuu.Core.Interactions.ApplicationCommands
{
    public static class ApplicationCommands
    {
        public static List<ApplicationCommand> GlobalApplicationCommands { get; } = new()
        {
            new Global.ChatInput.Welcome()
        };

        public static List<ApplicationCommand> GuildApplicationCommands { get; } = new() { };

        public static async Task<DiscordApi.Interactions.ApplicationCommands.ApplicationCommand[]> RegisterGlobalApplicationCommands(AuthorizationToken authorizationToken)
        {
            DiscordApi.Interactions.ApplicationCommands.ApplicationCommand[] applicationCommands =
                await DiscordApi.Interactions.ApplicationCommands.ApplicationCommands.BulkOverwriteGlobalApplicationCommands(
                    GlobalApplicationCommands.ToArray(),
                    Kafuu.Application.General.ApplicationId,
                    authorizationToken);

            return applicationCommands;
        }
    }
}

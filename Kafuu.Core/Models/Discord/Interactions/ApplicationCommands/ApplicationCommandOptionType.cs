namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

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

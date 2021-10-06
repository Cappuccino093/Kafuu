namespace Kafuu.Core.Models.Discord;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TokenType
{
	Bearer,
	Bot
}

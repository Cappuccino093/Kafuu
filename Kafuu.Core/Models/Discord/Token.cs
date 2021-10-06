namespace Kafuu.Core.Models.Discord;

public record Token
{
	public string Value { get; init; }
	public TokenType Type { get; init; }
}

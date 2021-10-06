namespace Kafuu.Core.Models.Discord.Topics.OAuth2;

public record ClientCredentialsAccessToken
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; private init; }

	[JsonPropertyName("token_type")]
	public TokenType TokenType { get; private init; }

	[JsonPropertyName("expires_in")]
	public int ExpiresIn { get; private init; }

	[JsonPropertyName("scope")]
	public string Scope { get; private init; }

	public ClientCredentialsAccessToken(string accessToken, TokenType tokenType, int expiresIn, string scope)
	{
		this.AccessToken = accessToken;
		this.TokenType = tokenType;
		this.ExpiresIn = expiresIn;
		this.Scope = scope;
	}
}

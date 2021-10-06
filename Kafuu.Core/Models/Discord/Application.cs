namespace Kafuu.Core.Models.Discord;

public struct Application
{
	public GeneralConfiguration General { get; set; }
	public OAuth2Configuration OAuth2 { get; set; }
	public BotConfiguration Bot { get; set; }

	[JsonConstructor]
	public Application(GeneralConfiguration general, OAuth2Configuration oAuth2, BotConfiguration bot)
	{
		this.General = general;
		this.OAuth2 = oAuth2;
		this.Bot = bot;
	}

	public struct GeneralConfiguration
	{
		public Snowflake ApplicationId { get; set; }
		public string PublicKey { get; set; }

		[JsonConstructor]
		public GeneralConfiguration(Snowflake applicationId, string publicKey)
		{
			this.ApplicationId = applicationId;
			this.PublicKey = publicKey;
		}
	}

	public struct OAuth2Configuration
	{
		public Snowflake ClientId { get; set; }
		public string ClientSecret { get; set; }

		[JsonConstructor]
		public OAuth2Configuration(Snowflake clientId, string clientSecret)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
		}
	}

	public struct BotConfiguration
	{
		public string Token { get; set; }

		[JsonConstructor]
		public BotConfiguration(string token) => this.Token = token;
	}
}

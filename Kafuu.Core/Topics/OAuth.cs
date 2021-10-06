using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Kafuu.Core.Models.Discord.Topics.OAuth2;

namespace Kafuu.Core.Topics;

public static class OAuth2
{
	private static readonly OAuth2Scope[] s_oAuth2Scopes = new OAuth2Scope[]
	{
		OAuth2Scope.ApplicationsCommandsUpdate
	};
	//private static readonly string s_authorizationUrl = "/oauth2/authorize";
	private static readonly string s_tokenUrl = "/oauth2/token";
	//private static readonly string s_tokenRevocationUrl = "/oauth2/token/revoke";

	public static async Task<ClientCredentialsAccessToken> ClientCredentialsGrant()
	{
		// New request
		HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, s_tokenUrl);

		// Request headers
		httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(
			"Basic",
			Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Kafuu.Application.OAuth2.ClientId}:{Kafuu.Application.OAuth2.ClientSecret}")));

		// Request body
		httpRequestMessage.Content = new FormUrlEncodedContent(new Dictionary<string, string>
			{
				{ "grant_type", "client_credentials" },
				{ "scope", $"{String.Join(' ', s_oAuth2Scopes.Select(oAuth2Scope => ConvertToDotCase(oAuth2Scope.ToString())))}" }
			});
		httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

		// Response
		HttpResponseMessage httpResponseMessage = await Kafuu.HttpClient.SendAsync(httpRequestMessage);

		return httpResponseMessage.IsSuccessStatusCode
			? Serialization.Serializer.Deserialize<ClientCredentialsAccessToken>(await httpResponseMessage.Content.ReadAsStringAsync())
			: throw new Exception($"{httpResponseMessage.StatusCode}: {await httpResponseMessage.Content.ReadAsStringAsync()}");
	}

	private static string ConvertToDotCase(string @string) =>
		String.Concat(@string.Select((x, i) => i > 0 && Char.IsUpper(x) ? "." + x.ToString() : x.ToString())).ToLower();
}

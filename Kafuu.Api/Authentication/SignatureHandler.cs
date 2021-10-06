using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Kafuu.Api.Authentication;

public class SignatureHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
	public SignatureHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
		: base(options, logger, encoder, clock)
	{ }

	protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
	{
		// Getting variables
		this.Context.Request.EnableBuffering();
		byte[] byteBoddy = new byte[Convert.ToInt32(this.Context.Request.ContentLength)];
		_ = await this.Request.Body.ReadAsync(byteBoddy);
		string body = Encoding.UTF8.GetString(byteBoddy);
		this.Request.Body.Position = 0;

		string timestamp = this.Request.Headers["X-Signature-Timestamp"];
		string signature = this.Request.Headers["X-Signature-Ed25519"];

#pragma warning disable CA2254 // Template should be a static expression
		this.Logger.LogInformation($"Signature: {signature}");
		this.Logger.LogInformation($"Timestamp: {timestamp}");
		this.Logger.LogInformation($"Body: {body}");
#pragma warning restore CA2254 // Template should be a static expression

		// Http Request Message
		HttpRequestMessage httpRequestMessage = new(
			HttpMethod.Get,
			new Uri("https://kafuu-kafuufunctions-kafuufunctionstypescript.azurewebsites.net/api/SignatureValidation"));

		httpRequestMessage.Headers.Add("Signature", signature);
		httpRequestMessage.Headers.Add("Timestamp", timestamp);
		httpRequestMessage.Headers.Add("PublicKey", Core.Kafuu.Application.General.PublicKey);

		httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
			
		// Http Response Message
		HttpClient httpClient = new();
		HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

		Claim[]? claims = new[] { new Claim("Signature", signature) };
		ClaimsIdentity? identity = new(claims, nameof(SignatureHandler));
		AuthenticationTicket? ticket = new(new ClaimsPrincipal(identity), this.Scheme.Name);

		return httpResponseMessage.IsSuccessStatusCode
			? AuthenticateResult.Success(ticket)
			: AuthenticateResult.Fail("Not verified signature.");
	}
}

using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

namespace Kafuu.Core.Interactions;

public static class ApplicationCommands
{
	public static List<Models.Kafuu.ApplicationCommand> GlobalApplicationCommands { get; } = new();

	static ApplicationCommands()
	{
		IEnumerable<Type> types =
			Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(type => type.Namespace.StartsWith("Kafuu.Core.Interactions.ApplicationCommandsList.Global"))
			.Where(type => type.IsClass);

		foreach (Type type in types)
			GlobalApplicationCommands.Add((Models.Kafuu.ApplicationCommand)Activator.CreateInstance(type));
	}

	public static async Task<Models.Discord.Interactions.ApplicationCommands.ApplicationCommand[]> BulkOverwriteGlobalApplicationCommands()
	{
		// New request
		HttpRequestMessage httpRequestMessage = new(
			HttpMethod.Put,
			$"applications/{Kafuu.Application.General.ApplicationId}/commands");

		// Request headers
		httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Authorization", $"Bot {Kafuu.Application.Bot.Token}");

		// Request body
		CreateApplicationCommand createApplicationCommand = (CreateApplicationCommand)GlobalApplicationCommands[1];

		httpRequestMessage.Content = new StringContent(Serialization.Serializer.Serialize(
			GlobalApplicationCommands.ConvertAll(applicationCommand => (CreateApplicationCommand)applicationCommand)));
		httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

		// Response
		HttpResponseMessage httpResponseMessage = await Kafuu.HttpClient.SendAsync(httpRequestMessage);

		return httpResponseMessage.IsSuccessStatusCode
			? Serialization.Serializer.Deserialize<Models.Discord.Interactions.ApplicationCommands.ApplicationCommand[]>(await httpResponseMessage.Content.ReadAsStringAsync())
			: throw new Exception($"{httpResponseMessage.StatusCode}: {await httpResponseMessage.Content.ReadAsStringAsync()}");
	}

	public static async Task<Models.Discord.Interactions.ApplicationCommands.ApplicationCommand[]> GetGlobalApplicationCommands()
	{
		// New request
		HttpRequestMessage httpRequestMessage = new(
			HttpMethod.Get,
			$"/applications/{Kafuu.Application.General.ApplicationId}/commands");

		// Request headers
		httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(
			"Authorization",
			$"Bot {Kafuu.Application.Bot.Token}");

		// Response
		HttpResponseMessage httpResponseMessage = await Kafuu.HttpClient.SendAsync(httpRequestMessage);

		return httpResponseMessage.IsSuccessStatusCode
			? Serialization.Serializer.Deserialize<Models.Discord.Interactions.ApplicationCommands.ApplicationCommand[]>(await httpResponseMessage.Content.ReadAsStringAsync())
			: throw new Exception($"{httpResponseMessage.StatusCode}: {await httpResponseMessage.Content.ReadAsStringAsync()}");
	}
}

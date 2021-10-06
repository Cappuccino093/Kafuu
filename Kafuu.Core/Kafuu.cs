global using System;
global using System.Collections.Generic;
global using System.Drawing;
global using System.Linq;
global using System.Net.Http;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using Kafuu.Core.Models.Discord;
global using Kafuu.Core.Models.Kafuu;
global using Kafuu.Core.Serialization.Converters;
using Microsoft.Extensions.Configuration;

namespace Kafuu.Core;

public static class Kafuu
{
	internal static readonly Uri s_baseAddress = new($"https://discord.com/api/{ApiVersion.v9}");

	public static Application Application { get; private set; } = new();
	public static Color Color { get; } = Color.LightBlue;
	internal static HttpClient HttpClient { get; } = new();
	public static JsonSerializerOptions JsonSerializerOptions { get; } = new();

	static Kafuu()
	{
		// Application Configuration
		IConfigurationRoot configurationRoot = new ConfigurationBuilder()
			.AddJsonFile("Application.json")
			.Build();

		Application = configurationRoot.Get<Application>();

		// Serializer Options
		JsonSerializerOptions.Converters.Add(new Serialization.Converters.ColorConverter());

		// HTTP Client Options
		HttpClient.BaseAddress = s_baseAddress;
		HttpClient.DefaultRequestHeaders.Clear();
	}
}

using DiscordApi.Interactions.ApplicationCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kafuu.Core.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void SerializeAndDeserializeColorAndUri()
    {
        Prueba prueba = new(
            Color.FromArgb(0x2196F3),
            new("https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0"));

        string json = JsonSerializer.Serialize(prueba);
        Console.WriteLine(json);
    }

    private record Prueba
    {
        [JsonConverter(typeof(ColorConverter))]
        public Color Color { get; init; }
        public Uri Url { get; init; }

        public Prueba(Color color, Uri url) =>
            (Color, Url) = (color, url);
    }

    private class ColorConverter : JsonConverter<Color>
    {
        public override Color Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            Color.FromArgb(Convert.ToInt32(reader.GetString()));

        public override void Write(
            Utf8JsonWriter writer,
            Color value,
            JsonSerializerOptions options) =>
            writer.WriteNumberValue(value.ToArgb());
    }

    [TestMethod]
    public void SnakeCaseNamingPolicy()
    {
        ApplicationCommand applicationCommand = new(default, default, "A", "Prueba", default);
        string json = DiscordApi.DiscordApi.Serialize(applicationCommand);

        Console.WriteLine(json);
    }

    [TestMethod]
    public void SnakeCaseNamingPolicyJsonStringEnumConverter()
    {

    }

    [TestMethod]
    public void Configuration()
    {
        Console.WriteLine(Kafuu.Application);
        Console.WriteLine(Kafuu.Application.Kafuu.Color.Name);
    }
}
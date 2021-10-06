using Kafuu.Core.Models.Discord.Interactions.MessageComponents;
using Kafuu.Core.Models.Discord.Resources.Channel;

namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public record InteractionCallbackData
{
	[JsonPropertyName("tts"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Tts { get; init; }

	[JsonPropertyName("content"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Content { get; init; }

	[JsonPropertyName("embeds"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Embed[]> Embeds { get; init; }

	[JsonPropertyName("allowed_mentions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<AllowedMentions> AllowedMentions { get; init; }

	[JsonPropertyName("flags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Flags { get; init; }

	[JsonPropertyName("components"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<IComponent[]> Components { get; init; }

	public InteractionCallbackData(
		Optional<bool> tts = default,
		Optional<string> content = default,
		Optional<Embed[]> embeds = default,
		Optional<AllowedMentions> allowedMentions = default,
		Optional<int> flags = default,
		Optional<IComponent[]> components = default)
	{
		this.Tts = tts;
		this.Content = content;
		this.Embeds = embeds;
		this.AllowedMentions = allowedMentions;
		this.Flags = flags;
		this.Components = components;
	}
}

using System.ComponentModel;

namespace Kafuu.Core.Models.Discord.Interactions.MessageComponents;

public record ActionRowComponent : IComponent
{
	[JsonPropertyName("type")]
	public ComponentType Type { get; private init; }

	[JsonPropertyName("components"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Component[]> Components { get; init; }

	ComponentType IComponent.Type { get; }
	Optional<string> IComponent.CustomId { get; init; }
	Optional<bool> IComponent.Disabled { get; init; }
	Optional<ButtonStyle> IComponent.Style { get; init; }
	Optional<string> IComponent.Label { get; init; }
	Optional<SelectOption.PartialEmoji> IComponent.Emoji { get; init; }
	Optional<string> IComponent.Url { get; init; }
	SelectOption[] IComponent.Options { get; }
	Optional<string> IComponent.Placeholder { get; init; }
	Optional<int> IComponent.MinValues { get; init; }
	Optional<int> IComponent.MaxValue { get; init; }
	Optional<Component[]> IComponent.Components { get; init; }

	public ActionRowComponent(Optional<Component[]> components = default)
	{
		this.Type = ComponentType.ActionRow;
		this.Components = components;
	}
}
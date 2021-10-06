using static Kafuu.Core.Models.Discord.Interactions.MessageComponents.SelectOption;
using System.ComponentModel;

namespace Kafuu.Core.Models.Discord.Interactions.MessageComponents;

public interface IComponent
{
	public ComponentType Type { get; }
	public Optional<string> CustomId { get; init; }
	public Optional<bool> Disabled { get; init; }
	public Optional<ButtonStyle> Style { get; init; }
	public Optional<string> Label { get; init; }
	public Optional<PartialEmoji> Emoji { get; init; }
	public Optional<string> Url { get; init; }
	public SelectOption[] Options { get; }
	public Optional<string> Placeholder { get; init; }
	public Optional<int> MinValues { get; init; }
	public Optional<int> MaxValue { get; init; }
	public Optional<Component[]> Components { get; init; }
}

using static Kafuu.Core.Models.Discord.Interactions.MessageComponents.SelectOption;

namespace Kafuu.Core.Models.Discord.Interactions.MessageComponents;

public record ButtonComponent : IComponent
{
	private Optional<string> _label;

	[JsonPropertyName("type")]
	public ComponentType Type { get; private init; }

	[JsonPropertyName("custom_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> CustomId { get; init; }

	[JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Disabled { get; init; }

	[JsonPropertyName("style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ButtonStyle> Style { get; init; }

	public Optional<string> Label
	{
		get => this._label;
		init
		{
			if (((string)value).Length > 80)
				throw new ArgumentException("Label can only have a maximum of 80 characters.");

			this._label = value;
		}
	}

	[JsonPropertyName("emoji"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<PartialEmoji> Emoji { get; init; }

	[JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Url { get; init; }

	SelectOption[] IComponent.Options { get; }
	Optional<string> IComponent.Placeholder { get; init; }
	Optional<int> IComponent.MinValues { get; init; }
	Optional<int> IComponent.MaxValue { get; init; }
	Optional<System.ComponentModel.Component[]> IComponent.Components { get; init; }

	public ButtonComponent(
		Optional<string> customId = default,
		Optional<bool> disabled = default,
		Optional<ButtonStyle> style = default,
		Optional<string> label = default,
		Optional<PartialEmoji> emoji = default,
		Optional<string> url = default)
	{
		this.Type = ComponentType.Button;
		this.CustomId = customId;
		this.Disabled = disabled;
		this.Style = style;
		this.Label = label;
		this.Emoji = emoji;
		this.Url = url;
	}
}

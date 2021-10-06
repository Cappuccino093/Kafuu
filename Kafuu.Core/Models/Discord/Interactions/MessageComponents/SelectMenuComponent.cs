namespace Kafuu.Core.Models.Discord.Interactions.MessageComponents;

public record SelectMenuComponent : IComponent
{
	private SelectOption[] _options;
	private Optional<string> _placeholder;
	private Optional<int> _minValues;
	private Optional<int> _maxValue;

	[JsonPropertyName("type")]
	public ComponentType Type { get; private init; }

	[JsonPropertyName("custom_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> CustomId { get; init; }

	[JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Disabled { get; init; }

	[JsonPropertyName("options")]
	public SelectOption[] Options
	{
		get => this._options;
		init
		{
			if (value.Length > 25)
				throw new ArgumentException("Options only can have a length of 25.");

			this._options = value;
		}
	}

	[JsonPropertyName("placeholder"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Placeholder
	{
		get => this._placeholder;
		init
		{
			if (((string)value).Length > 100)
				throw new ArgumentException("Placeholder can only have a maximum of 100 characters.");

			this._placeholder = value;
		}
	}

	[JsonPropertyName("min_values"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> MinValues
	{
		get => this._minValues;
		init
		{
			if ((int)value is not (>= 0 and <= 25))
				throw new ArgumentException("Min Values must be between 0 and 25.");

			this._minValues = value;
		}
	}

	[JsonPropertyName("max_value"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> MaxValue
	{
		get => this._maxValue;
		init
		{
			if ((int)value is not (>= 0 and <= 25))
				throw new ArgumentException("Max Values must be between 0 and 25.");

			this._maxValue = value;
		}
	}

	Optional<ButtonStyle> IComponent.Style { get; init; }
	Optional<string> IComponent.Label { get; init; }
	Optional<SelectOption.PartialEmoji> IComponent.Emoji { get; init; }
	Optional<string> IComponent.Url { get; init; }
	Optional<System.ComponentModel.Component[]> IComponent.Components { get; init; }

	public SelectMenuComponent(
		SelectOption[] options,
		Optional<string> customId = default,
		Optional<bool> disabled = default,
		Optional<string> placeholder = default,
		Optional<int> minValues = default,
		Optional<int> maxValue = default)
	{
		this.Type = ComponentType.SelectMenu;
		this.CustomId = customId;
		this.Disabled = disabled;
		this.Options = options;
		this.Placeholder = placeholder;
		this.MinValues = minValues;
		this.MaxValue = maxValue;
	}
}

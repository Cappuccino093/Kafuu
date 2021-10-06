using System.Text.RegularExpressions;

namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

public record ApplicationCommandOption
{
	private string _name;
	private string _description;
	private Optional<ApplicationCommandOptionChoice[]> _choices;
	private Optional<ApplicationCommandOption[]> _options;

	[JsonPropertyName("type")]
	public ApplicationCommandOptionType Type { get; init; }

	[JsonPropertyName("name")]
	public string Name
	{
		get => this._name;
		private init
		{
			if (!new Regex(@"^[\w-]{1,32}$").IsMatch(value))
				throw new ArgumentException("Value must be a 1-32 lowercase character name matching ^[\\w-]{1,32}$");

			this._name = value;
		}
	}

	[JsonPropertyName("description")]
	public string Description
	{
		get => this._description;
		private init
		{
			if (value.Length is not (>= 0 and <= 100))
				throw new ArgumentException("Value must be a 1-100 character description");

			this._description = value;
		}
	}

	[JsonPropertyName("required"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Required { get; init; }

	[JsonPropertyName("choices"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandOptionChoice[]> Choices
	{
		get => this._choices;
		init
		{
			if (((ApplicationCommandOptionChoice[])value).Length > 25)
				throw new ArgumentException("Value must be an array of maximum 25 Application Command Option Choice.");

			this._choices = value;
		}
	}

	[JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandOption[]> Options
	{
		get => this._options;
		init
		{
			if (((ApplicationCommandOption[])value).Length > 25)
				throw new ArgumentException("Application Command Options must be an array of maximum 25 ApplicationCommandOption.");

			Array.Sort((ApplicationCommandOption[])value, (option1, option2) => option2.Required.CompareTo(option1.Required));
			Array.Reverse((ApplicationCommandOption[])value);

			this._options = value;
		}
	}

	public ApplicationCommandOption(
		ApplicationCommandOptionType type,
		string name,
		string description,
		Optional<bool> required = default,
		Optional<ApplicationCommandOptionChoice[]> choices = default,
		Optional<ApplicationCommandOption[]> options = default)
	{
		this.Type = type;
		this.Name = name;
		this.Description = description;
		this.Required = required;
		this.Choices = choices;
		this.Options = options;
	}
}

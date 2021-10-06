namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

public record ApplicationCommandOptionChoice
{
	private string _name;
	private dynamic _value;

	[JsonPropertyName("name")]
	public string Name
	{
		get => this._name;
		private init
		{
			if (value.Length is not (>= 0 and <= 100))
				throw new ArgumentException("Value must be a 1-100 character string.");

			this._name = value;
		}
	}

	[JsonPropertyName("value")]
	public dynamic Value
	{
		get => this._value;
		private init
		{
			if (value is not (string or int or double))
				throw new ArgumentException("Value must be of type string, int or double.");

			if (value is string @string && !(@string.Length >= 0 && @string.Length <= 100))
				throw new ArgumentException("Value of type string must be a 1-100 character string.");

			this._value = value;
		}
	}

	public ApplicationCommandOptionChoice(string name, dynamic value)
	{
		this.Name = name;
		this.Value = value;
	}
}

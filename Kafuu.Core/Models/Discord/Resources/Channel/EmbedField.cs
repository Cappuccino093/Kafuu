namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record EmbedField
{
	private string _name;
	private string _value;

	[JsonPropertyName("name")]
	public string Name
	{
		get => this._name;
		private init
		{
			if (!(value.Length <= 256))
				throw new ArgumentException("Name must contain a maximum of 256 characters.");

			this._name = value;
		}
	}

	[JsonPropertyName("value")]
	public string Value
	{
		get => this._value;
		private init
		{
			if (!(value.Length <= 1024))
				throw new ArgumentException("Value must contain a maximum of 1024 characters.");

			this._value = value;
		}
	}

	[JsonPropertyName("inline"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Inline { get; init; }

	public EmbedField(
		string name,
		string value,
		Optional<bool> inline = default)
	{
		this.Name = name;
		this.Value = value;
		this.Inline = inline;
	}
}

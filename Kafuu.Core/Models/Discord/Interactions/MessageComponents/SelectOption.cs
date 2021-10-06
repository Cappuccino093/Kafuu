using Kafuu.Core.Models.Discord.Resources.Emoji;
using Kafuu.Core.Models.Discord.Resources.User;
using Kafuu.Core.Models.Discord.Topics.Permissions;

namespace Kafuu.Core.Models.Discord.Interactions.MessageComponents;

public record SelectOption
{
	private string _label;
	private string _value;
	private Optional<string> _description;

	[JsonPropertyName("label")]
	public string Label
	{
		get => this._label;
		private init
		{
			if (value.Length > 100)
				throw new ArgumentException("Label can only have a maximum of 100 characters.");

			this._label = value;
		}
	}

	[JsonPropertyName("value")]
	public string Value
	{
		get => this._value;
		private init
		{
			if (value.Length > 100)
				throw new ArgumentException("Value can only have a maximum of 100 characters");

			this._value = value;
		}
	}

	[JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Description
	{
		get => this._description;
		init
		{
			if (((string)value).Length > 100)
				throw new ArgumentException("Description can only have a maximum of 100 characters.");

			this._description = value;
		}
	}

	[JsonPropertyName("emoji"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<PartialEmoji> Emoji { get; init; }

	[JsonPropertyName("default"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Default { get; init; }

	public SelectOption(
	string label,
	string value,
	Optional<string> description = default,
	Optional<PartialEmoji> emoji = default,
	Optional<bool> @default = default)
	{
		this.Label = label;
		this.Value = value;
		this.Description = description;
		this.Emoji = emoji;
		this.Default = @default;
	}

	public record PartialEmoji : IEmoji
	{
		[JsonPropertyName("id")]
		public Snowflake? Id { get; init; }

		[JsonPropertyName("name")]
		public string? Name { get; init; }

		[JsonPropertyName("animated"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Optional<bool> Animated { get; init; }

		Optional<Role> IEmoji.Roles { get; init; }
		Optional<User> IEmoji.User { get; init; }
		Optional<bool> IEmoji.RequireColons { get; init; }
		Optional<bool> IEmoji.Managed { get; init; }
		Optional<bool> IEmoji.Available { get; init; }

		public PartialEmoji(
			Snowflake? id,
			string? name,
			Optional<bool> animated = default)
		{
			this.Id = id;
			this.Name = name;
			this.Animated = animated;
		}
	}
}

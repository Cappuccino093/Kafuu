namespace Kafuu.Core.Models.Discord.Resources.Sticker;

public record Sticker
{
	private string _tags;

	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("pack_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> PackId { get; init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("description")]
	public string? Description { get; private init; }

	[JsonPropertyName("tags")]
	public string Tags
	{
		get => this._tags;
		private init
		{
			if (value.Length > 200)
				throw new ArgumentException("Tags can only have a maximum of 200 characters.");

			this._tags = value;
		}
	}

	[JsonPropertyName("asset")]
	public string Asset { get; private init; }

	[JsonPropertyName("type")]
	public StickerType Type { get; private init; }

	[JsonPropertyName("format_type")]
	public StickerFormatType FormatType { get; private init; }

	[JsonPropertyName("available"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Available { get; init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; init; }

	[JsonPropertyName("user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<User.User> User { get; init; }

	[JsonPropertyName("sort_value"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> SortValue { get; init; }

	public Sticker(
		Snowflake id,
		string name,
		string? description,
		string tags,
		string asset,
		StickerType type,
		StickerFormatType formatType,
		Optional<Snowflake> packId = default,
		Optional<bool> available = default,
		Optional<Snowflake> guildId = default,
		Optional<User.User> user = default,
		Optional<int> sortValue = default)
	{
		this.Id = id;
		this.PackId = packId;
		this.Name = name;
		this.Description = description;
		this.Tags = tags;
		this.Asset = asset;
		this.Type = type;
		this.FormatType = formatType;
		this.Available = available;
		this.GuildId = guildId;
		this.User = user;
		this.SortValue = sortValue;
	}
}

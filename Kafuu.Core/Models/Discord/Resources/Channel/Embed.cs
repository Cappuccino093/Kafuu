namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record Embed
{
	private Optional<string> _title;
	private Optional<string> _description;
	private Optional<EmbedFooter> _footer;
	private Optional<EmbedAuthor> _author;
	private Optional<EmbedField[]> _fields;

	[JsonPropertyName("title"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Title
	{
		get => this._title;
		init
		{
			if (!(((string)value).Length < 256))
				throw new ArgumentException("Title must contain a maximum of 256 characters.");

			this._title = value;

			this.CheckCharacters();
		}
	}

	[JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedType> Type { get; init; }

	[JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Description
	{
		get => this._description;
		init
		{
			if (!(((string)value).Length < 4096))
				throw new ArgumentException("Description must contain a maximum of 4096 characters.");

			this._description = value;

			this.CheckCharacters();
		}
	}

	[JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> Url { get; init; }

	[JsonPropertyName("timestamp"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<DateTime> Timestamp { get; init; }

	[JsonPropertyName("color"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Color> Color { get; init; }

	[JsonPropertyName("footer"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedFooter> Footer
	{
		get => this._footer;
		init
		{
			this._footer = value;

			this.CheckCharacters();
		}
	}

	[JsonPropertyName("image"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedImage> Image { get; init; }

	[JsonPropertyName("thumbnail"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedThumbnail> Thumbnail { get; init; }

	[JsonPropertyName("video"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedVideo> Video { get; init; }

	[JsonPropertyName("provider"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedProvider> Provider { get; init; }

	[JsonPropertyName("author"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedAuthor> Author
	{
		get => this._author;
		init
		{
			this._author = value;

			this.CheckCharacters();
		}
	}

	[JsonPropertyName("fields"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<EmbedField[]> Fields
	{
		get => this._fields;
		init
		{
			if (((EmbedField[])value).Length > 25)
				throw new ArgumentException("Fields array must contain a maximum of 25 fields.");

			this._fields = value;

			this.CheckCharacters();
		}
	}

	public Embed(
		Optional<string> title = default,
		Optional<EmbedType> type = default,
		Optional<string> description = default,
		Optional<Uri> url = default,
		Optional<DateTime> timestamp = default,
		Optional<Color> color = default,
		Optional<EmbedFooter> footer = default,
		Optional<EmbedImage> image = default,
		Optional<EmbedThumbnail> thumbnail = default,
		Optional<EmbedVideo> video = default,
		Optional<EmbedProvider> provider = default,
		Optional<EmbedAuthor> author = default,
		Optional<EmbedField[]> fields = default)
	{
		this.Title = title;
		this.Type = type;
		this.Description = description;
		this.Url = url;
		this.Timestamp = timestamp;
		this.Color = color;
		this.Footer = footer;
		this.Image = image;
		this.Thumbnail = thumbnail;
		this.Video = video;
		this.Provider = provider;
		this.Author = author;
		this.Fields = fields;
	}

	private void CheckCharacters()
	{
		int characters = 0;
		characters += ((string)this._title).Length;
		characters += ((string)this._description).Length;
		characters += ((EmbedFooter)this._footer).Text.Length;
		characters += ((EmbedAuthor)this._author).Name.Length;
		foreach (EmbedField field in (EmbedField[])this._fields)
		{
			characters += field.Name.Length;
			characters += field.Value.Length;
		}

		if (characters > 6000)
		{
			throw new ArgumentException("The characters of Title, Description, Footer.Text, Author.Name, Field.Name and Field.Value " +
				"must contain a maximum of 6000 characters.");
		}
	}
}

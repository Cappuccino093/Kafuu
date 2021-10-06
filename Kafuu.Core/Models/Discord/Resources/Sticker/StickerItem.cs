namespace Kafuu.Core.Models.Discord.Resources.Sticker;

public record StickerItem
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("format_type")]
	public StickerFormatType FormatType { get; private init; }

	public StickerItem(Snowflake id, string name, StickerFormatType formatType)
	{
		this.Id = id;
		this.Name = name;
		this.FormatType = formatType;
	}
}

using System.Drawing;

namespace DiscordApi.Resources.Channel;

public record Embed
{
    private string _title;
    private string _description;
    private Optional<EmbedField[]> _fields;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Title
    {
        get => _title;
        init
        {
            if (!(((string)value).Length < 256))
                throw new ArgumentException("Title must contain a maximum of 256 characters.");

            _title = (string)value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedType> Type { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Description
    {
        get => _description;
        init
        {
            if (!(((string)value).Length < 4096))
                throw new ArgumentException("Description must contain a maximum of 4096 characters.");

            _description = (string)value;
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Uri> Url { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<DateTime> Timestamp { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Color> Color { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedFooter> Footer { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedImage> Image { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedThumbnail> Thumbnail { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedVideo> Video { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedProvider> Provider { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedAuthor> Author { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<EmbedField[]> Fields
    {
        get => _fields;
        init
        {
            if (((EmbedField[])value).Length > 25)
                throw new ArgumentException("Fields array must contain a maximum of 25 fields.");

            _fields = value;
        }
    }

    public Embed(
        Optional<string> title,
        Optional<EmbedType> type,
        Optional<string> description,
        Optional<Uri> url,
        Optional<DateTime> timestamp,
        Optional<Color> color,
        Optional<EmbedFooter> footer,
        Optional<EmbedImage> image,
        Optional<EmbedThumbnail> thumbnail,
        Optional<EmbedVideo> video,
        Optional<EmbedProvider> provider,
        Optional<EmbedAuthor> author,
        Optional<EmbedField[]> fields)
    {
        int characters = 0;
        characters += ((string)title).Length;
        characters += ((string)description).Length;
        characters += ((EmbedFooter)footer).Text.Length;
        characters += ((EmbedAuthor)author).Name.Length;
        foreach (EmbedField field in (EmbedField[])fields)
        {
            characters += field.Name.Length;
            characters += field.Value.Length;
        }

        if (characters > 6000)
            throw new ArgumentException("The characters of Title, Description, Footer.Text, Author.Name, Field.Name and Field.Value " +
                "must contain a maximum of 6000 characters.");

        Title = title;
        Type = type;
        Description = description;
        Url = url;
        Timestamp = timestamp;
        Color = color;
        Footer = footer;
        Image = image;
        Thumbnail = thumbnail;
        Video = video;
        Provider = provider;
        Author = author;
        Fields = fields;
    }
}

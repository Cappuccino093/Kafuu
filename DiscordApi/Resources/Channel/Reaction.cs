namespace DiscordApi.Resources.Channel;

public record Reaction
{
    public int Count { get; }
    public bool Me { get; }
    public Emoji.Emoji Emoji { get; }

    public Reaction(
        int count,
        bool me,
        Emoji.Emoji emoji) =>
        (Count, Me, Emoji) =
        (count, me, emoji);
}

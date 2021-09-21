namespace DiscordApi.Resources.Channel;

public record ThreadMetadata
{
    public bool Archived { get; }
    public int AutoArchiveDuration { get; }
    public DateTime ArchiveTimestamp { get; }
    public bool Locked { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Invitable { get; init; }

    public ThreadMetadata(
        bool archived,
        int autoArchiveDuration,
        DateTime archiveTimestamp,
        bool locked,
        Optional<bool> invitable = default) =>
        (Archived, AutoArchiveDuration, ArchiveTimestamp, Locked, Invitable) =
        (archived, autoArchiveDuration, archiveTimestamp, locked, invitable);
}

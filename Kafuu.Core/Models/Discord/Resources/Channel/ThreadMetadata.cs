namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record ThreadMetadata
{
	[JsonPropertyName("archived")]
	public bool Archived { get; private init; }

	[JsonPropertyName("auto_archive_duration")]
	public int AutoArchiveDuration { get; private init; }

	[JsonPropertyName("archive_timestamp")]
	public DateTime ArchiveTimestamp { get; private init; }

	[JsonPropertyName("locked")]
	public bool Locked { get; private init; }

	[JsonPropertyName("invitable"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> Invitable { get; init; }

	public ThreadMetadata(
		bool archived,
		int autoArchiveDuration,
		DateTime archiveTimestamp,
		bool locked,
		Optional<bool> invitable = default)
	{
		this.Archived = archived;
		this.AutoArchiveDuration = autoArchiveDuration;
		this.ArchiveTimestamp = archiveTimestamp;
		this.Locked = locked;
		this.Invitable = invitable;
	}
}

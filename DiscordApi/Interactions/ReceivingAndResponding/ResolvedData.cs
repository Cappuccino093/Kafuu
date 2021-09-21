using DiscordApi.Resources.Channel;
using DiscordApi.Resources.Guild;
using DiscordApi.Resources.User;
using DiscordApi.Topics.Permissions;
using System.Collections.Generic;

namespace DiscordApi.Interactions.ReceivingAndResponding;

public record ResolvedData
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Dictionary<Snowflake, User>> Users { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Dictionary<Snowflake, PartialMember>> Members { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Dictionary<Snowflake, Role>> Roles { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Dictionary<Snowflake, PartialChannel>> Channels { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<Dictionary<Snowflake, PartialMessage>> Messages { get; init; }

    public record PartialMember : GuildMember
    {
#pragma warning disable IDE0051
        private new readonly Optional<User> User;
        private new readonly bool Deaf;
        private new readonly bool Mute;
#pragma warning restore IDE0051

        public PartialMember(
            Snowflake[] roles,
            DateTime joinedAt,
            Optional<string?> nick = default,
            Optional<DateTime?> premiumSince = default,
            Optional<bool> pending = default,
            Optional<string> permissions = default) :
            base(roles, joinedAt, default, default, default, nick, premiumSince, pending, permissions)
        { }
    }

    public record PartialChannel : Channel
    {
#pragma warning disable IDE0051
        private new readonly Optional<Snowflake> GuildId;
        private new readonly Optional<int> Position;
        private new readonly Optional<Overwrite[]> PermissionOverwrites;
        private new readonly Optional<string?> Topic;
        private new readonly Optional<bool> Nsfw;
        private new readonly Optional<Snowflake?> LastMessageId;
        private new readonly Optional<int> Bitrate;
        private new readonly Optional<int> UserLimit;
        private new readonly Optional<int> RateLimitPerUser;
        private new readonly Optional<User[]> Recipients;
        private new readonly Optional<string?> Icon;
        private new readonly Optional<Snowflake> OwnerId;
        private new readonly Optional<Snowflake> ApplicationId;
        private new readonly Optional<DateTime?> LastPinTimestamp;
        private new readonly Optional<string?> RtcRegion;
        private new readonly Optional<int> VideoQualityMode;
        private new readonly Optional<int> MessageCount;
        private new readonly Optional<int> MemberCount;
        private new readonly Optional<ThreadMember> Member;
        private new readonly Optional<int> DefaultAutoArchiveDuration;
#pragma warning restore IDE0051

        public PartialChannel(
            Snowflake id,
            ChannelType type,
            Optional<string> name = default,
            Optional<Snowflake?> parentId = default,
            Optional<ThreadMetadata> threadMetadata = default,
            Optional<string> permissions = default) :
            base(
                id,
                type,
                default,
                default,
                default,
                name,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                parentId,
                default,
                default,
                default,
                default,
                default,
                threadMetadata,
                default,
                default,
                permissions)
        { }
    }

    public record PartialMessage : Message { }
}

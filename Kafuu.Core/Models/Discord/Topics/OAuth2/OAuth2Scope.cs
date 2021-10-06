using System.Runtime.Serialization;

namespace Kafuu.Core.Models.Discord.Topics.OAuth2;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum OAuth2Scope
{
	[EnumMember(Value = "activities.read")]
	ActivitiesRead,

	[EnumMember(Value = "activities.write")]
	ActivitiesWrite,

	[EnumMember(Value = "applications.builds.read")]
	ApplicationsBuildsRead,

	[EnumMember(Value = "applications.builds.upload")]
	ApplicationsBuildsUpload,

	[EnumMember(Value = "applications.commands")]
	ApplicationsCommands,

	[EnumMember(Value = "applications.commands.update")]
	ApplicationsCommandsUpdate,

	[EnumMember(Value = "applications.entitlements")]
	ApplicationsEntitlements,

	[EnumMember(Value = "applications.store.update")]
	ApplicationsStoreUpdate,

	[EnumMember(Value = "bot")]
	Bot,

	[EnumMember(Value = "connections")]
	Connections,

	[EnumMember(Value = "email")]
	Email,

	[EnumMember(Value = "gdm.join")]
	GdmJoin,

	[EnumMember(Value = "guilds")]
	Guilds,

	[EnumMember(Value = "guilds.join")]
	GuildsJoin,

	[EnumMember(Value = "identify")]
	Identify,

	[EnumMember(Value = "messages.read")]
	MessagesRead,

	[EnumMember(Value = "relationships.read")]
	RelationshipsRead,

	[EnumMember(Value = "rpc")]
	Rpc,

	[EnumMember(Value = "rpc.activities.write")]
	RpcActivitiesWrite,

	[EnumMember(Value = "rpc.notifications.read")]
	RpcNotificationsRead,

	[EnumMember(Value = "rpc.voice.read")]
	RpcVoiceRead,

	[EnumMember(Value = "rpc.voice.write")]
	RpcVoiceWrite,

	[EnumMember(Value = "webhook.incoming")]
	WebhookIncoming
}

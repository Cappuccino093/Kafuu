using System.Runtime.Serialization;

namespace Kafuu.Core.Models.Discord.Resources.Channel;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum AllowedMentionType
{
	[EnumMember(Value = "roles")]
	RolesMentions,

	[EnumMember(Value = "users")]
	UsersMentions,

	[EnumMember(Value = "everyone")]
	EveryoneMentions
}

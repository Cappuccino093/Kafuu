using System.Runtime.Serialization;

namespace Kafuu.Core.Models.Discord.Resources.Channel;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum EmbedType
{
	[EnumMember(Value = "rich")]
	Rich,

	[EnumMember(Value = "image")]
	Image,
	
	[EnumMember(Value = "video")]
	Video,

	[EnumMember(Value = "gifv")]
	Gifv,

	[EnumMember(Value = "article")]
	Article,

	[EnumMember(Value = "link")]
	Link
}

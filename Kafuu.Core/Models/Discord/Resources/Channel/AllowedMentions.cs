namespace Kafuu.Core.Models.Discord.Resources.Channel;

public record AllowedMentions
{
	private Snowflake[] _roles;
	private Snowflake[] _users;

	[JsonPropertyName("parse")]
	public AllowedMentionType[] Parse { get; private init; }

	[JsonPropertyName("roles")]
	public Snowflake[] Roles
	{
		get => _roles;
		private init
		{
			if (value.Length > 100)
				throw new ArgumentException("Array can only have a maximum of 100 Roles.");

			_roles = value;
		}
	}

	[JsonPropertyName("users")]
	public Snowflake[] Users
	{
		get => _users;
		private init
		{
			if (value.Length > 100)
				throw new ArgumentException("Array can only have a maximum of 100 Users.");

			_users = value;
		}
	}

	[JsonPropertyName("replied_user")]
	public bool RepliedUser { get; private init; }

	public AllowedMentions(AllowedMentionType[] parse, Snowflake[] roles, Snowflake[] users, bool repliedUser)
	{
		this.Parse = parse;
		this.Roles = roles;
		this.Users = users;
		this.RepliedUser = repliedUser;
	}
}

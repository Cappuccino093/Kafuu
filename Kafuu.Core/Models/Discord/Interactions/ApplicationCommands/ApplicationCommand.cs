using System.Text.RegularExpressions;

namespace Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;

public record ApplicationCommand : IApplicationCommand
{
	private string _name;
	private string _description;
	private Optional<ApplicationCommandOption[]> _options;

	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandType> Type { get; init; }

	[JsonPropertyName("application_id")]
	public Snowflake ApplicationId { get; private init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; init; }

	[JsonPropertyName("name")]
	public string Name
	{
		get => this._name;
		private init
		{
			if (this.Type != default(Optional<ApplicationCommandType>) && this.Type == ApplicationCommandType.ChatInput && !new Regex(@"^[\w-]{1,32}$").IsMatch(value))
				throw new ArgumentException("Name of Chat Input Application Commands must be a 1-32 lowercase character name matching ^[\\w-]{1,32}$");

			this._name = value;
		}
	}

	[JsonPropertyName("description")]
	public string Description
	{
		get => this._description;
		private init
		{
			if (value.Length is not (>= 1 and <= 100))
				throw new ArgumentException("Value must be a 1-100 character string.");

			if (this.Type != default(Optional<ApplicationCommandType>) && this.Type != ApplicationCommandType.ChatInput && !String.IsNullOrEmpty(value))
				throw new ArgumentException("Value of Commands of type User and Message must be empty strings.");

			this._description = value;
		}
	}

	[JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<ApplicationCommandOption[]> Options
	{
		get => this._options;
		init
		{
			if (value != default(Optional<ApplicationCommandOption[]>))
			{
				if (((ApplicationCommandOption[])value).Length > 0 && this.Type != ApplicationCommandType.ChatInput)
					throw new ArgumentException("Application Command Options can only be used on an Application Command with type ChatInput.");

				if (((ApplicationCommandOption[])value).Length > 25)
					throw new ArgumentException("Application Command Options must be an array of maximum 25 ApplicationCommandOption.");

				Array.Sort((ApplicationCommandOption[])value, (option1, option2) => option2.Required.CompareTo(option1.Required));
			}

			this._options = value;
		}
	}

	[JsonPropertyName("default_premission"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<bool> DefaultPermission { get; init; }

	[JsonPropertyName("version")]
	public Snowflake Version { get; private init; }

	public ApplicationCommand(
		Snowflake id,
		Snowflake applicationId,
		string name,
		string description,
		Snowflake version,
		Optional<ApplicationCommandType> type = default,
		Optional<Snowflake> guildId = default,
		Optional<ApplicationCommandOption[]> options = default,
		Optional<bool> defaultPermission = default)
	{
		this.Id = id;
		this.Type = type;
		this.ApplicationId = applicationId;
		this.GuildId = guildId;
		this.Name = name;
		this.Description = description;
		this.Options = options;
		this.DefaultPermission = defaultPermission;
		this.Version = version;
	}
}

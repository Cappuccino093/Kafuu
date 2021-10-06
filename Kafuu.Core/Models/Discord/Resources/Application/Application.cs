using Kafuu.Core.Models.Discord.Topics.Teams;

namespace Kafuu.Core.Models.Discord.Resources.Application;

public record Application
{
	[JsonPropertyName("id")]
	public Snowflake Id { get; private init; }

	[JsonPropertyName("name")]
	public string Name { get; private init; }

	[JsonPropertyName("icon")]
	public string? Icon { get; private init; }

	[JsonPropertyName("description")]
	public string Description { get; private init; }

	[JsonPropertyName("rpc_origins"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri[]> RpcOrigins { get; init; }

	[JsonPropertyName("bot_public")]
	public bool BotPublic { get; private init; }

	[JsonPropertyName("bot_require_code_grant")]
	public bool BotRequireCodeGrant { get; private init; }

	[JsonPropertyName("terms_of_service_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> TermsOfServiceUrl { get; init; }

	[JsonPropertyName("privacy_policy_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Uri> PrivacyPolicyUrl { get; init; }

	[JsonPropertyName("owner"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<User.User> Owner { get; init; }

	[JsonPropertyName("summary")]
	public string Summary { get; private init; }

	[JsonPropertyName("verify_key")]
	public string VerifyKey { get; private init; }

	[JsonPropertyName("team")]
	public Team? Team { get; private init; }

	[JsonPropertyName("guild_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> GuildId { get; init; }

	[JsonPropertyName("primary_sku_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<Snowflake> PrimarySkuId { get; init; }

	[JsonPropertyName("slug"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> Slug { get; init; }

	[JsonPropertyName("cover_image"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<string> CoverImage { get; init; }

	[JsonPropertyName("flags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Optional<int> Flags { get; init; }

	public Application(
		Snowflake id,
		string name,
		string? icon,
		string description,
		bool botPublic,
		bool botRequireCodeGrant,
		string summary,
		string verifyKey,
		Team? team,
		Optional<Uri[]> rpcOrigins = default,
		Optional<Uri> termsOfServiceUrl = default,
		Optional<Uri> privacyPolicyUrl = default,
		Optional<User.User> owner = default,
		Optional<Snowflake> guildId = default,
		Optional<Snowflake> primarySkuId = default,
		Optional<string> slug = default,
		Optional<string> coverImage = default,
		Optional<int> flags = default)
	{
		this.Id = id;
		this.Name = name;
		this.Icon = icon;
		this.Description = description;
		this.RpcOrigins = rpcOrigins;
		this.BotPublic = botPublic;
		this.BotRequireCodeGrant = botRequireCodeGrant;
		this.TermsOfServiceUrl = termsOfServiceUrl;
		this.PrivacyPolicyUrl = privacyPolicyUrl;
		this.Owner = owner;
		this.Summary = summary;
		this.VerifyKey = verifyKey;
		this.Team = team;
		this.GuildId = guildId;
		this.PrimarySkuId = primarySkuId;
		this.Slug = slug;
		this.CoverImage = coverImage;
		this.Flags = flags;
	}
}

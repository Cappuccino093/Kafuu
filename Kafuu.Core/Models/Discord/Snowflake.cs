namespace Kafuu.Core.Models.Discord;

[JsonConverter(typeof(SnowflakeConverter))]
public struct Snowflake
{
	public static implicit operator Snowflake(ulong value) => new(value);
	public static explicit operator ulong(Snowflake snowflake) => snowflake.Value;

	public ulong Value { get; private init; }
	public DateTimeOffset Timestamp { get; private init; }
	public ulong InternalWorkerId { get; private init; }
	public ulong InternalProcessId { get; private init; }
	public ulong Increment { get; private init; }

	public Snowflake(ulong value)
	{
		this.Value = value;
		string binaryValue = Convert.ToString((long)value, 2).PadLeft(64, '0');

		this.Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)(Convert.ToUInt64(binaryValue.Substring(22, 42), 2) + 1420070400000));
		this.InternalWorkerId = Convert.ToUInt64(binaryValue.Substring(17, 5), 2);
		this.InternalProcessId = Convert.ToUInt64(binaryValue.Substring(12, 5), 2);
		this.Increment = Convert.ToUInt64(binaryValue.Substring(0, 12), 2);
	}

	public Snowflake() : this(0) { }

	public override string ToString() => this.Value.ToString();
}

namespace DiscordApi;

[JsonConverter(typeof(SnowflakeConverter))]
public struct Snowflake
{
    public ulong Value { get; }
    public DateTimeOffset Timestamp { get; }
    public ulong InternalWorkerId { get; }
    public ulong InternalProcessId { get; }
    public ulong Increment { get; }

    public static implicit operator Snowflake(ulong value) => new(value);
    public static explicit operator ulong(Snowflake snowflake) => snowflake.Value;

    public Snowflake(ulong value)
    {
        Value = value;
        string binaryValue = Convert.ToString((long)value, 2).PadLeft(64, '0');

        Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)(Convert.ToUInt64(binaryValue.Substring(22, 42), 2) + 1420070400000));
        InternalWorkerId = Convert.ToUInt64(binaryValue.Substring(17, 5), 2);
        InternalProcessId = Convert.ToUInt64(binaryValue.Substring(12, 5), 2);
        Increment = Convert.ToUInt64(binaryValue.Substring(0, 12), 2);
    }
}

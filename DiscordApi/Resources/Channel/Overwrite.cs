namespace DiscordApi.Resources.Channel;

public struct Overwrite
{
    public Snowflake Id { get; }
    public int Type { get; }
    public string Allow { get; }
    public string Deny { get; }

    public Overwrite(
        Snowflake id,
        int type,
        string allow,
        string deny) =>
        (Id, Type, Allow, Deny) = (id, type, allow, deny);
}

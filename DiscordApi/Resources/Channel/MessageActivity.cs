namespace DiscordApi.Resources.Channel;

public record MessageActivity
{
    public MessageActivityType Type { get; }
    public string PartyId { get; }

    public MessageActivity(MessageActivityType type, string partyId) =>
        (Type, PartyId) = (type, partyId);
}

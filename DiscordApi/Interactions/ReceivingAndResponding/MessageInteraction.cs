using DiscordApi.Resources.User;

namespace DiscordApi.Interactions.ReceivingAndResponding;

public record MessageInteraction
{
    public Snowflake Id { get; }
    public InteractionType Type { get; }
    public string Name { get; }
    public User User { get; }

    public MessageInteraction(Snowflake id, InteractionType type, string name, User user) =>
        (Id, Type, Name, User) = (id, type, name, user);
}

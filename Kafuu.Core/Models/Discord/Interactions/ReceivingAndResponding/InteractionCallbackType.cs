namespace Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

public enum InteractionCallbackType
{
	Pong = 1,
	ChannelMessageWithSource = 4,
	DeferredChannelMessageWithSource,
	DeferredUpdateMessage,
	UpdateMessage
}

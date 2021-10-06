using Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;

namespace Kafuu.Core.Interactions.ApplicationCommandsList.Global.ChatInput;

public class Welcome : ApplicationCommand
{
	// Application Command
	private static readonly string s_name = "Welcome";
	private static readonly string s_description = "A basic welcoming command";

	// Interaction Callback Data
	private static readonly bool s_tts = false;
	private static readonly string s_content =
@"Hi! This is a basic welcoming testing purpose command.
I am not ready for complex tasks yet but you can appreciate this message as an advance for my development.
If you like this project, don't forget to visit my repository at GitHub (https://github.com/Cappuccino093/Kafuu) and give me some love. 💙
Have a great day! ☕";

	public Welcome() : base(s_name, s_description) { }

	public override InteractionCallbackData InteractionCallback() => new(s_tts, s_content);
}

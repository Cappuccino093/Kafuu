using System;

namespace Kafuu.Core.Interactions.ApplicationCommands.Global.ChatInput
{
    public record Welcome : ApplicationCommand
    {
        private readonly static string _name = "welcome";
        private readonly static string _description = "A basic welcoming command!";

        public Welcome() : base(_name, _description) { }

        public override void Execute()
        {
            Console.WriteLine("Hello!!!\n" +
                "This command is work in progress...");
        }
    }
}

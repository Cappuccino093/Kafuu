using Kafuu.Console.Models.Menu;

namespace Kafuu.Console.Menu.Menus;

internal class ApplicationCommands : Models.Menu.Menu
{
	private static readonly string s_name = "Application Commands";
	private static readonly Option[] s_options = new[]
	{
			new Option(
				"Register application commands to Discord",
				() => { })
	};

	public ApplicationCommands() : base(s_name, s_options) { }
}

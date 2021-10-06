using Kafuu.Console.Models.Menu;

namespace Kafuu.Console.Menu.Menus;

internal class MainMenu : Models.Menu.Menu
{
	private static readonly string s_name = "Main Menu";
	private static readonly Option[] s_options = new[]
	{
			new Option(
				"Commands",
				() =>
				{

				}),
			new Option(
				"Topics",
				() =>
				{

				})
		};

	internal MainMenu() : base(s_name, s_options) { }
}

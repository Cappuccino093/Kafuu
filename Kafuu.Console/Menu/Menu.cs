using Kafuu.Console.Menu.Menus;
using Kafuu.Console.Models.Menu;

namespace Kafuu.Console.Menu;

internal class Menu
{
	internal static Models.Menu.Menu MainMenu { get; } = new MainMenu();

	internal static void Start() => Show(MainMenu);

	internal static void Show(Models.Menu.Menu menu)
	{
		Menu:
		Writter.Clear();
		Writter.Write($" --- {menu.Name} --- ", 3, 1);

		sbyte counter = 1;
		foreach (Option option in menu.Options)
		{
			Writter.Write($" {counter}. {option.Name}");
			counter++;
		}

		Writter.Write(" 0. Exit");

		sbyte selection = Selection();

		if (selection > menu.Options.Length || selection < 0)
		{
			Writter.Write("You have selected a wrong option.", null, null, Color.Error);
			_ = System.Console.ReadKey();
			goto Menu;
		}

		if (selection-- == 0)
			return;

		menu.Options[selection].Action.Invoke();
	}

	internal static sbyte Selection(int? posX = null, int? posY = null)
	{
		Writter.Write("");
		Writter.Write(" Select an option: ", posX, posY);

		sbyte option;
		try
		{
			option = Reader.ReadNumberKey();
		}
		catch
		{
			option = -1;
		}

		Writter.Write("");
		return option;
	}
}

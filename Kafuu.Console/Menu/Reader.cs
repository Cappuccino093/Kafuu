using Kafuu.Console.Models.Menu;

namespace Kafuu.Console.Menu;

internal static class Reader
{
	internal static sbyte ReadNumberKey()
	{
		System.Console.ForegroundColor = (ConsoleColor)Color.Secondary;
		sbyte option = SByte.Parse(System.Console.ReadKey().KeyChar.ToString());

		return option;
	}
}

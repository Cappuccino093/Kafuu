using Kafuu.Console.Models.Menu;

namespace Kafuu.Console.Menu;

internal class Writter
{
	private static int s_posX = 0;
	private static int s_posY = 0;

	public static void Write(string message, int? posX = null, int? posY = null, Color? color = null)
	{
		posX ??= s_posX;
		posY ??= s_posY;

		System.Console.SetCursorPosition((int)posX, (int)posY);
		System.Console.ForegroundColor = (ConsoleColor?)color ?? (ConsoleColor)Color.Primary;
		System.Console.Write(message);

		s_posX = (int)posX;
		s_posY = (int)(posY + 1);
	}

	public static void Clear() => System.Console.Clear();
}

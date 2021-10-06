using Kafuu.Console.Models.Menu;

namespace Kafuu.Console.Log;

internal class Logger
{
	public static void Start()
	{
		System.Console.Clear();
		System.Console.SetCursorPosition(0, 0);
	}

	public static void Log(string logMessage, Color? color = null)
	{
		System.Console.ForegroundColor = (ConsoleColor?)color ?? ConsoleColor.White;
		System.Console.WriteLine($"{DateTime.Now.TimeOfDay} {logMessage}");
	}
}

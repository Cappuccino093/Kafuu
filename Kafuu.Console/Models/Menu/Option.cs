namespace Kafuu.Console.Models.Menu;

internal class Option
{
	internal string Name { get; private init; }
	internal Action Action { get; private init; }

	public Option(string name, Action action)
	{
		this.Name = name;
		this.Action = action;
	}
}

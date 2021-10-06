namespace Kafuu.Console.Models.Menu;

internal abstract class Menu
{
	internal string Name { get; private init; }
	internal Option[] Options { get; private init; }

	internal Menu(string name, Option[] options)
	{
		if (options.Length > 9)
			throw new ArgumentException("Options can't be longer than 9.");

		this.Name = name;
		this.Options = options;
	}
}

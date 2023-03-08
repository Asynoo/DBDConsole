namespace DBDConsole;

public class MenuPrinter
{
    public static int Show()
    {
        Console.WriteLine("Please enter a number to choose an exercise:");
        Console.WriteLine("1. Create a department");
        Console.WriteLine("2. Update a department name");
        Console.WriteLine("3. Update a department manager");
        Console.WriteLine("4. Delete a department");
        Console.WriteLine("5. Get a department by id");
        Console.WriteLine("6. Get all departments");
        Console.WriteLine("0. Exit");

        var choice = int.Parse(Console.ReadLine()!);
        Console.WriteLine();

        return choice;
    }
}
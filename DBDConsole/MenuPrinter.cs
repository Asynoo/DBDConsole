namespace DBDConsole;

public class MenuPrinter
{
    public static int Show()
    {
        Console.WriteLine("\n Please Choose an Excersise!: \n ");
        Console.WriteLine("1. Create a Department");
        Console.WriteLine("2. Update a Department Name");
        Console.WriteLine("3. Update a Department Manager");
        Console.WriteLine("4. Delete a Department");
        Console.WriteLine("5. Get a Department Info");
        Console.WriteLine("6. Get All Departments Info");
        Console.WriteLine("0. Exit \n ");

        var choice = int.Parse(Console.ReadLine()!);
        Console.WriteLine();

        return choice;
    }
}
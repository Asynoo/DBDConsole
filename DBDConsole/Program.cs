using System.Data.SqlClient;
using DBDConsole;
using DBDConsole.Cases;

internal class Program
{
    private static void Main(string[] args)
    {
        SqlConnection connection = Database.GetConnection();
        
        while (true)
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

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Case1.Run(connection);
                    break;

                case 2:
                    Console.Clear();
                    Case2.Run(connection);
                    break;

                case 3:
                    Console.Clear();
                    Case3.Run(connection);
                    break;

                case 4:
                    Console.Clear();
                    Case4.Run(connection);
                    break;

                case 5:
                    Console.Clear();
                    Case5.Run(connection);
                    break;

                case 6:
                    Console.Clear();
                    Case6.Run(connection);
                    break;
                
            }
        }
    }
}
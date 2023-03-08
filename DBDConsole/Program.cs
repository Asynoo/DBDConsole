using System.Data.SqlClient;
using DBDConsole.Cases;

internal class Program
{
    private static void Main(string[] args)
    {
        const string connectionString = "Server=localhost\\SQLEXPRESS;Database=Company;Trusted_Connection=True;";
        var connection = new SqlConnection(connectionString);

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
                    Case1.Run(connection);
                    break;

                case 2:
                    Case2.Run(connection);
                    break;

                case 3:
                    Case3.Run(connection);
                    break;

                case 4:
                    Case4.Run(connection);
                    break;

                case 5:
                    Case5.Run(connection);
                    break;

                case 6:
                    Case6.Run(connection);
                    break;
            }
        }
    }
}
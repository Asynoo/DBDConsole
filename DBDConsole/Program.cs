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
            var choice = MenuPrinter.Show();

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
                
                case 0:
                    Console.WriteLine("Goodbye!");
                    return;
                
            }
        }
    }
}
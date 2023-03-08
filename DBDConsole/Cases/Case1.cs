using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case1
{
    public static void Run(SqlConnection connection)
    {
        Console.WriteLine("Please enter department name:");
        var departmentName = Console.ReadLine();
        var managerSSN = 0;
        var validManagerSSN = false;

        while (!validManagerSSN)
        {
            Console.WriteLine("Please enter manager SSN:");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out managerSSN))
            {
                Console.WriteLine("Invalid SSN. Please enter a valid integer SSN.");
            }
            else
            {
                var checkManagerSSNCommand =
                    new SqlCommand("SELECT COUNT(*) FROM Employee WHERE SSN = @SSN", connection);
                checkManagerSSNCommand.Parameters.AddWithValue("@SSN", managerSSN);

                connection.Open();
                var count = Convert.ToInt32(checkManagerSSNCommand.ExecuteScalar());
                connection.Close();

                if (count > 0)
                    validManagerSSN = true;
                else
                    Console.WriteLine($"Manager SSN {managerSSN} does not exist. Please enter a valid manager SSN.");
            }
        }

        var createDepartmentCommand = new SqlCommand("USP_CreateDepartment", connection);
        createDepartmentCommand.CommandType = CommandType.StoredProcedure;
        createDepartmentCommand.Parameters.AddWithValue("@DName", departmentName);
        createDepartmentCommand.Parameters.AddWithValue("@MgrSSN", managerSSN);

        connection.Open();
        createDepartmentCommand.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Department created successfully.");
    }
}
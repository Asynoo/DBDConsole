using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case3
{
    public static void Run(SqlConnection connection)
    {
        Console.WriteLine("Please enter department number:");
        var departmentNumber3 = int.Parse(Console.ReadLine());

        var commandA =
            new SqlCommand(
                "SELECT SSN, Fname, Lname FROM Employee WHERE Dno = @DNumber AND SSN NOT IN (SELECT MgrSSN FROM Department WHERE DNumber != @DNumber)",
                connection);
        commandA.Parameters.AddWithValue("@DNumber", departmentNumber3);

        connection.Open();
        var reader = commandA.ExecuteReader();

        // Display unassigned managers in console
        Console.WriteLine("Unassigned Managers:");
        Console.WriteLine("-------------------");
        while (reader.Read()) Console.WriteLine($"{reader["SSN"]}: {reader["Fname"]} {reader["Lname"]}");

        reader.Close();
        connection.Close();

        Console.WriteLine("Please enter new manager SSN:");
        var newManagerSSN3 = int.Parse(Console.ReadLine());

        // Execute stored procedure to update department manager
        var commandB = new SqlCommand("USP_UpdateDepartmentManager", connection);
        commandB.CommandType = CommandType.StoredProcedure;
        commandB.Parameters.AddWithValue("@DNumber", departmentNumber3);
        commandB.Parameters.AddWithValue("@MgrSSN", newManagerSSN3);

        connection.Open();
        commandB.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Department manager updated successfully.");
    }
}
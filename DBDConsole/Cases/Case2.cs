using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case2
{
    public static void Run(SqlConnection connection)
    {
        Console.WriteLine("Please choose a department number:");
        var command1 = new SqlCommand("SELECT DNumber, DName FROM Department", connection);
        connection.Open();
        var readerA = command1.ExecuteReader();
        while (readerA.Read()) Console.WriteLine($"{readerA["DNumber"]}: {readerA["DName"]}");
        readerA.Close();
        connection.Close();

        var departmentNumber2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter new department name:");
        var newDepartmentName2 = Console.ReadLine();

        var command2 = new SqlCommand("USP_UpdateDepartmentName", connection);
        command2.CommandType = CommandType.StoredProcedure;
        command2.Parameters.AddWithValue("@DNumber", departmentNumber2);
        command2.Parameters.AddWithValue("@DName", newDepartmentName2);

        connection.Open();
        command2.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Department updated successfully.");
    }
}
using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case4
{
    public static void Run(SqlConnection connection)
    {
        Console.WriteLine("Please enter department number:");
        var departmentNumber4 = int.Parse(Console.ReadLine());

        var command4 = new SqlCommand("USP_DeleteDepartment", connection);
        command4.CommandType = CommandType.StoredProcedure;
        command4.Parameters.AddWithValue("@DNumber", departmentNumber4);

        connection.Open();
        command4.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Department deleted successfully.");
    }
}
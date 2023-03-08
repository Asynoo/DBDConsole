using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case5
{
    public static void Run(SqlConnection connection)
    {
        Console.WriteLine("Please enter employee SSN:");
        int employeeSSN = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter project number:");
        int projectNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter hours worked on the project:");
        double hoursWorked = double.Parse(Console.ReadLine());

        SqlCommand command5 = new SqlCommand("USP_AddEmployeeToProject", connection);
        command5.CommandType = System.Data.CommandType.StoredProcedure;
        command5.Parameters.AddWithValue("@ESSN", employeeSSN);
        command5.Parameters.AddWithValue("@PNO", projectNumber);
        command5.Parameters.AddWithValue("@Hours", hoursWorked);

        connection.Open();
        command5.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Employee added to project successfully.");
    }
}
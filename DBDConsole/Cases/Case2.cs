using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case2
{
    public static void Run(SqlConnection connection)
    {
        Console.WriteLine("Please choose a department number:");
        SqlCommand command1 = new SqlCommand("SELECT DNumber, DName FROM Department", connection);
        connection.Open();
        SqlDataReader readerA = command1.ExecuteReader();
        while (readerA.Read())
        {
            Console.WriteLine($"{readerA["DNumber"]}: {readerA["DName"]}");
        }
        readerA.Close();
        connection.Close();

        int departmentNumber2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter new department name:");
        string newDepartmentName2 = Console.ReadLine();

        SqlCommand command2 = new SqlCommand("USP_UpdateDepartmentName", connection);
        command2.CommandType = System.Data.CommandType.StoredProcedure;
        command2.Parameters.AddWithValue("@DNumber", departmentNumber2);
        command2.Parameters.AddWithValue("@DName", newDepartmentName2);

        connection.Open();
        command2.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Department updated successfully.");
    }
}
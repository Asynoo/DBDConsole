using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case6
{
    public static void Run(SqlConnection connection)
    {
        SqlCommand command6 = new SqlCommand("USP_GetALLDepartments", connection);
        command6.CommandType = System.Data.CommandType.StoredProcedure;

        connection.Open();
        SqlDataReader reader6 = command6.ExecuteReader();

        Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-20} {4,-10}", "DNumber", "DName", "MgrSSN", "MgrStartDate", "EmpCount");

        while (reader6.Read())
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-20} {4,-10}", reader6["DNumber"], reader6["DName"], reader6["MgrSSN"], reader6["MgrStartDate"], reader6["EmpCount"]);
        }

        connection.Close();
    }
}
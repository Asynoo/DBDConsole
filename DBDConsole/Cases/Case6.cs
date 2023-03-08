using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case6
{
    public static void Run(SqlConnection connection)
    {
        var command = new SqlCommand("USP_GetALLDepartments", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Connection.Open();

        var reader = command.ExecuteReader();

        if (reader.HasRows)
            while (reader.Read())
            {
                int dNumber = (int)reader["DNumber"];
                string dName = (string)reader["DName"];
                decimal mgrSSN = (decimal)reader["MgrSSN"];
                DateTime mgrStartDate = (DateTime)reader["MgrStartDate"];
                int empCount = (int)reader["EmpCount"];
                
                Console.WriteLine($"Department Number: {dNumber}");
                Console.WriteLine($"Department Name: {dName}");
                Console.WriteLine($"Manager SSN: {mgrSSN}");
                Console.WriteLine($"Manager Start Date: {mgrStartDate}");
                Console.WriteLine($"Employee Count: {empCount} \n ");
            }

        else
            Console.WriteLine("No departments found.");

        reader.Close();
        command.Connection.Close();
    }
}
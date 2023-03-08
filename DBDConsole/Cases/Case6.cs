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
                var dNumber = (int)reader["DNumber"];
                var dName = (string)reader["DName"];
                var mgrSSN = (decimal)reader["MgrSSN"];
                var mgrStartDate = (DateTime)reader["MgrStartDate"];
                var empCount = (int)reader["EmpCount"];

                // Do something with the results
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
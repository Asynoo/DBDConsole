using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case5
{
    public static void Run(SqlConnection connection)
    {
        
        List<(int DNumber, string DName)> departments = new();

        var deptCommand = new SqlCommand("SELECT DNumber, DName FROM Department", connection);
        deptCommand.Connection.Open();

        var deptReader = deptCommand.ExecuteReader();

        while (deptReader.Read())
        {
            var dNumber = (int)deptReader["DNumber"];
            var dName = (string)deptReader["DName"];

            departments.Add((dNumber, dName));
        }

        deptReader.Close();
        deptCommand.Connection.Close();

        Console.WriteLine("Departments:");

        foreach (var dept in departments) Console.WriteLine($"  {dept.DNumber} - {dept.DName}");

        int departmentNumber;

        while (true)
        {
            Console.Write("Enter a department number: ");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out departmentNumber))
                Console.WriteLine("Invalid department number. Please enter a valid integer.");
            else if (!departments.Exists(d => d.DNumber == departmentNumber))
                Console.WriteLine($"Department {departmentNumber} does not exist. Please select a valid department.");
            else
                break;
        }

        var command = new SqlCommand("USP_GetDepartment", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@DNumber", departmentNumber);

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
            Console.WriteLine($"A department with the id {departmentNumber} does not exist.");

        reader.Close();
        command.Connection.Close();
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases
{
    public class Case3
    {
        public static void Run(SqlConnection connection)
        {
            Console.WriteLine("Please select a department:");
            
            var command = new SqlCommand("SELECT DNumber, DName FROM Department", connection);

            connection.Open();
            var reader = command.ExecuteReader();

            Console.WriteLine("Departments:");
            Console.WriteLine("------------");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["DNumber"]}: {reader["DName"]}");
            }

            reader.Close();

            Console.Write("Department number: ");
            var departmentNumber = int.Parse(Console.ReadLine());

            var commandA = new SqlCommand("SELECT SSN, Fname, Lname FROM Employee WHERE Dno = @DNumber AND SSN NOT IN (SELECT MgrSSN FROM Department WHERE DNumber != @DNumber)", connection);
            commandA.Parameters.AddWithValue("@DNumber", departmentNumber);

            reader = commandA.ExecuteReader();

            Console.WriteLine("Unassigned Managers:");
            Console.WriteLine("-------------------");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["SSN"]}: {reader["Fname"]} {reader["Lname"]}");
            }

            reader.Close();

            Console.Write("New manager SSN: ");
            var newManagerSSN = int.Parse(Console.ReadLine());

            var commandB = new SqlCommand("USP_UpdateDepartmentManager", connection);
            commandB.CommandType = CommandType.StoredProcedure;
            commandB.Parameters.AddWithValue("@DNumber", departmentNumber);
            commandB.Parameters.AddWithValue("@MgrSSN", newManagerSSN);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            commandB.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Department manager updated successfully.");
        }
    }
}

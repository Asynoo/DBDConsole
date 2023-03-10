using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases
{
    public class Case5
    {
        public static void Run(SqlConnection connection)
        {
            List<(int DNumber, string DName)> departments = new();

            var deptCommand = new SqlCommand("SELECT DNumber, DName FROM Department", connection);

            connection.Open();

            var deptReader = deptCommand.ExecuteReader();

            while (deptReader.Read())
            {
                var dNumber = deptReader.GetInt32(0);
                var dName = deptReader.GetString(1);

                departments.Add((dNumber, dName));
            }

            deptReader.Close();

            Console.WriteLine("Departments:");

            foreach (var dept in departments)
            {
                Console.WriteLine($"  {dept.DNumber} - {dept.DName}");
            }

            int departmentNumber;

            while (true)
            {
                Console.Write("Enter a department number: ");

                var input = Console.ReadLine();

                if (!int.TryParse(input, out departmentNumber))
                {
                    Console.WriteLine("Invalid department number. Please enter a valid integer.");
                }
                else if (!departments.Exists(d => d.DNumber == departmentNumber))
                {
                    Console.WriteLine($"Department {departmentNumber} does not exist. Please select a valid department.");
                }
                else
                {
                    break;
                }
            }

            var command = new SqlCommand("USP_GetDepartment", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DNumber", departmentNumber);

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dNumber = reader.GetInt32(0);
                    var dName = reader.GetString(1);
                    var mgrSSN = reader.GetDecimal(2);
                    var mgrStartDate = reader.GetDateTime(3);
                    var empCount = reader.GetInt32(4);

                    Console.WriteLine($"Department Number: {dNumber}");
                    Console.WriteLine($"Department Name: {dName}");
                    Console.WriteLine($"Manager SSN: {mgrSSN}");
                    Console.WriteLine($"Manager Start Date: {mgrStartDate}");
                    Console.WriteLine($"Employee Count: {empCount} \n ");
                }
            }
            else
            {
                Console.WriteLine($"A department with the id {departmentNumber} does not exist.");
            }

            reader.Close();
            connection.Close();
        }
    }
}

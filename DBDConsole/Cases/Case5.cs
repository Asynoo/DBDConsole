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
            // Retrieve a list of departments from the database
            List<(int DNumber, string DName)> departments = new List<(int, string)>();

            SqlCommand deptCommand = new SqlCommand("SELECT DNumber, DName FROM Department", connection);
            deptCommand.Connection.Open();

            SqlDataReader deptReader = deptCommand.ExecuteReader();

            while (deptReader.Read())
            {
                int dNumber = (int)deptReader["DNumber"];
                string dName = (string)deptReader["DName"];

                departments.Add((dNumber, dName));
            }

            deptReader.Close();
            deptCommand.Connection.Close();

            // Display the list of departments to the user
            Console.WriteLine("Departments:");

            foreach (var dept in departments)
            {
                Console.WriteLine($"  {dept.DNumber} - {dept.DName}");
            }

            // Prompt the user to select a department
            int departmentNumber;

            while (true)
            {
                Console.Write("Enter a department number: ");

                string input = Console.ReadLine();

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

            // Call the stored procedure with the selected department number
            SqlCommand command = new SqlCommand("USP_GetDepartment", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DNumber", departmentNumber);

            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int dNumber = (int)reader["DNumber"];
                    string dName = (string)reader["DName"];
                    decimal mgrSSN = (decimal)reader["MgrSSN"];
                    DateTime mgrStartDate = (DateTime)reader["MgrStartDate"];
                    int empCount = (int)reader["EmpCount"];

                    // Do something with the results
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
            command.Connection.Close();
        }
    }
}

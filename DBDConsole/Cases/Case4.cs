using System;
using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases
{
    public class Case4
    {
        public static void Run(SqlConnection connection)
        {
            Console.Write("Please enter department number: ");
            int departmentNumber = int.Parse(Console.ReadLine());

            var deleteDepartmentCommand = new SqlCommand("USP_DeleteDepartment", connection);
            deleteDepartmentCommand.CommandType = CommandType.StoredProcedure;
            deleteDepartmentCommand.Parameters.AddWithValue("@DNumber", departmentNumber);

            connection.Open();
            deleteDepartmentCommand.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Department deleted successfully.");
        }
    }
}

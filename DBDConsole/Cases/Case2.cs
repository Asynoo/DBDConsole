using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases
{
    public class Case2
    {
        public static void Run(SqlConnection connection)
        {
            Console.WriteLine("Please choose a department number:");
            var selectDepartmentsCommand = new SqlCommand("SELECT DNumber, DName FROM Department", connection);

            connection.Open();
            using (var reader = selectDepartmentsCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["DNumber"]}: {reader["DName"]}");
                }
            }
            connection.Close();

            Console.WriteLine("Please enter the department number:");
            int departmentNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter new department name:");
            string newDepartmentName = Console.ReadLine();

            var updateDepartmentCommand = new SqlCommand("USP_UpdateDepartmentName", connection);
            updateDepartmentCommand.CommandType = CommandType.StoredProcedure;
            updateDepartmentCommand.Parameters.AddWithValue("@DNumber", departmentNumber);
            updateDepartmentCommand.Parameters.AddWithValue("@DName", newDepartmentName);

            connection.Open();
            updateDepartmentCommand.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Department updated successfully.");
        }
    }
}
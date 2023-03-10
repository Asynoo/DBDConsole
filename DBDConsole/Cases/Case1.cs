using System.Data;
using System.Data.SqlClient;

namespace DBDConsole.Cases
{
    public class Case1
    {
        public static void Run(SqlConnection connection)
        {
            Console.WriteLine("Please enter department name:");
            string departmentName = Console.ReadLine();

            int managerSSN;
            while (true)
            {
                Console.WriteLine("Please enter manager SSN:");
                if (int.TryParse(Console.ReadLine(), out managerSSN))
                {
                    var checkManagerSSNCommand = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE SSN = @SSN", connection);
                    checkManagerSSNCommand.Parameters.AddWithValue("@SSN", managerSSN);

                    connection.Open();
                    int count = (int)checkManagerSSNCommand.ExecuteScalar();
                    connection.Close();

                    if (count > 0) break;
                }

                Console.WriteLine($"Invalid manager SSN. Please enter a valid integer SSN.");
            }

            var createDepartmentCommand = new SqlCommand("USP_CreateDepartment", connection);
            createDepartmentCommand.CommandType = CommandType.StoredProcedure;
            createDepartmentCommand.Parameters.AddWithValue("@DName", departmentName);
            createDepartmentCommand.Parameters.AddWithValue("@MgrSSN", managerSSN);

            connection.Open();
            createDepartmentCommand.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Department created successfully.");
        }
    }
}
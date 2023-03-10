using System.Data.SqlClient;

public class Case6
{
    public static void Run(SqlConnection connection)
    {
        using var command = new SqlCommand("USP_GetALLDepartments", connection);
        connection.Open();

        using var reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int dNumber = reader.GetInt32(0);
                string dName = reader.GetString(1);
                decimal mgrSSN = reader.GetDecimal(2);
                DateTime mgrStartDate = reader.GetDateTime(3);
                int empCount = reader.GetInt32(4);

                Console.WriteLine($"Department Number: {dNumber}");
                Console.WriteLine($"Department Name: {dName}");
                Console.WriteLine($"Manager SSN: {mgrSSN}");
                Console.WriteLine($"Manager Start Date: {mgrStartDate}");
                Console.WriteLine($"Employee Count: {empCount} \n ");
            }
        }
        else
        {
            Console.WriteLine("No departments found.");
        }
    }
}

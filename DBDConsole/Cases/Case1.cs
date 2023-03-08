using System.Data.SqlClient;

namespace DBDConsole.Cases;

public class Case1
{
    public static void Run(SqlConnection connection)
    {
                      Console.WriteLine("Please enter department name:");
                        string departmentName = Console.ReadLine();
                        int managerSSN = 0;
                        bool validManagerSSN = false;

                        while (!validManagerSSN)
                        {
                            Console.WriteLine("Please enter manager SSN:");
                            string input = Console.ReadLine();

                            if (!int.TryParse(input, out managerSSN))
                            {
                                Console.WriteLine("Invalid SSN. Please enter a valid integer SSN.");
                            }
                            else
                            {
                                SqlCommand checkManagerSSNCommand = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE SSN = @SSN", connection);
                                checkManagerSSNCommand.Parameters.AddWithValue("@SSN", managerSSN);

                                connection.Open();
                                int count = Convert.ToInt32(checkManagerSSNCommand.ExecuteScalar());
                                connection.Close();

                                if (count > 0)
                                {
                                    validManagerSSN = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Manager SSN {managerSSN} does not exist. Please enter a valid manager SSN.");
                                }
                            }
                        }

                        SqlCommand createDepartmentCommand = new SqlCommand("USP_CreateDepartment", connection);
                        createDepartmentCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        createDepartmentCommand.Parameters.AddWithValue("@DName", departmentName);
                        createDepartmentCommand.Parameters.AddWithValue("@MgrSSN", managerSSN);

                        connection.Open();
                        createDepartmentCommand.ExecuteNonQuery();
                        connection.Close();

                        Console.WriteLine("Department created successfully.");
            }
        }
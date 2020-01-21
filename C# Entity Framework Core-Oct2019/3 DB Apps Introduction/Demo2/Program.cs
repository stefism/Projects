using System;
using System.Data.SqlClient;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection
                (@"Server=STEFCHO\SQLEXPRESS;Database=SoftUni;Integrated Security=True;");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand
                   ("SELECT * FROM Employees", connection);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var firstName = reader["FirstName"];
                        var lastName = reader["LastName"];
                        var title = reader["JobTitle"];

                        var result = firstName + " " + lastName + " " + title;

                        Console.WriteLine(result);
                    }
                    //---
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++) // FieldCount дава всички колони.
                        {
                            Console.Write(reader[i] + " ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

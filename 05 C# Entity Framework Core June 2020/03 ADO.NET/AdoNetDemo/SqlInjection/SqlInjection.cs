using Microsoft.Data.SqlClient;
using System;

namespace SqlInjection
{
    class SqlInjection
    {
        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            using SqlConnection sqlConnection = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=Service;Integrated Security=true");
            
            sqlConnection.Open();
            
            SqlCommand sqlCommand =
                new SqlCommand($"SELECT COUNT(*) FROM Users " +
                $"WHERE Username = '{username}' " +
                $"AND Password = '{password}'", sqlConnection); // Така не щото бау. Прави се с параметри.

            SqlCommand sqlCommandWithParam =
               new SqlCommand($"SELECT COUNT(*) FROM Users " +
               $"WHERE Username = '@Username' " +
               $"AND Password = '@Password'", sqlConnection); // Е те така.

            sqlCommandWithParam.Parameters.AddWithValue("@Username", username);
            sqlCommandWithParam.Parameters.AddWithValue("@Password", password);
            // Така се задават параметри на горното и нанай си инжектион.


            int usersCount = (int)sqlCommandWithParam.ExecuteScalar();

            if (usersCount > 0)
            {
                Console.WriteLine("Welcome to secret app.");
            }
            else
            {
                Console.WriteLine("Access denied.");
            }

        }
    }
}

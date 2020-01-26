using System;
using System.Data.SqlClient;

namespace _02_VillainNames
{
    class Program
    {
        private static string connString =
           @"Server=STEFCHO\SQLEXPRESS;
                Database=MinionsDB;
                Integrated Security=true";

        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connString);
            
            string sqlString =
                @"SELECT v.[Name], COUNT(m.[Name]) AS MinionsCount
                    FROM Villains v
                    JOIN MinionsVillains mv 
                    ON v.Id = mv.VillainId
                    JOIN Minions m
                    ON mv.MinionId = m.Id
                    GROUP BY v.[Name]
                    HAVING COUNT(m.[Name]) > 3
                    ORDER BY MinionsCount DESC";

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine
                            ($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }
            }
        }
    }
}

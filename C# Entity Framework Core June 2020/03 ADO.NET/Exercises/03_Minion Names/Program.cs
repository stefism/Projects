using Microsoft.Data.SqlClient;
using System;

namespace _03_Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            minionsDB.Open();

            string getVillainName =
                @"SELECT [Name]
                FROM Villains
                WHERE Id = @Id";

            SqlCommand getName = new SqlCommand(getVillainName, minionsDB);
            getName.Parameters.AddWithValue("@Id", villainId);
            string nameVillain = getName.ExecuteScalar() as string;

            if (nameVillain == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string getMinionsNames =
                @"SELECT m.[Name], m.Age
                FROM Villains AS v
                LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                LEFT JOIN Minions AS m ON mv.MinionId = m.Id
                WHERE v.Id = @Id
                ORDER BY m.[Name]";

            SqlCommand minionsNames = new SqlCommand(getMinionsNames, minionsDB);
            minionsNames.Parameters.AddWithValue("@Id", villainId);

            using SqlDataReader reader = minionsNames.ExecuteReader();

            Console.WriteLine($"Villain: {nameVillain}");
            int count = 1;

            while (reader.Read())
            {
                string minionName = reader["Name"]?.ToString();

                if (minionName == "")
                {
                    Console.WriteLine("(no minions)");
                    break;
                }

                int minionAge = (int)reader["Age"];

                Console.WriteLine($"{count++}. {minionName} {minionAge}");
            }
        }
    }
}

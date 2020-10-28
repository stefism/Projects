using Microsoft.Data.SqlClient;
using System;

namespace _02_Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            minionsDB.Open();

            string getMinions =
                @"SELECT v.[Name],
                COUNT(m.[Name]) AS MCount
                FROM Villains AS v
                JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                JOIN Minions AS m ON mv.MinionId = m.Id
                GROUP BY v.[Name]
                ORDER BY MCount DESC";

            SqlCommand getCountFromMinions = new SqlCommand(getMinions, minionsDB);

            using SqlDataReader reader = getCountFromMinions.ExecuteReader();

            while (reader.Read())
            {
                string villainsName = (string)reader["Name"];
                int minionCount = (int)reader["Mcount"];

                Console.WriteLine($"{villainsName} - {minionCount}");
            }
        }
    }
}

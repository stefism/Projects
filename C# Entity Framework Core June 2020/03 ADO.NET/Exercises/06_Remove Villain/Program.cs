using Microsoft.Data.SqlClient;
using System;

namespace _06_Remove_Villain
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
                Console.WriteLine("No such villain was found.");
                return;
            }

            string getMinionsCount =
                @"SELECT
                COUNT(m.[Name]) AS MCount
                FROM Villains AS v
                LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                LEFT JOIN Minions AS m ON mv.MinionId = m.Id
                WHERE v.[Name] = @VillainName";

            SqlCommand getMinionCountCmd = new SqlCommand(getMinionsCount, minionsDB);
            getMinionCountCmd.Parameters
                .AddWithValue("@VillainName", nameVillain);

            int minionCount = (int)getMinionCountCmd.ExecuteScalar();

            if (minionCount > 0)
            {
                string delVillainsFromMapingTableQuerty = "DELETE FROM MinionsVillains WHERE VillainId = @VillainId";
                
                SqlCommand delVillainsFromMapingCmd = new SqlCommand(delVillainsFromMapingTableQuerty, minionsDB);
                delVillainsFromMapingCmd
                    .Parameters.AddWithValue("@VillainId", villainId);
                delVillainsFromMapingCmd.ExecuteNonQuery();
            }

            string deleteVillainsFromDbQuery = "DELETE FROM Villains WHERE Id = @VillainId";

            SqlCommand delVillainFromDb = new SqlCommand(deleteVillainsFromDbQuery, minionsDB);
            delVillainFromDb.Parameters.AddWithValue("@VillainId", villainId);

            Console.WriteLine($"{nameVillain} was deleted.");
            Console.WriteLine($"{minionCount} minions were released.");
        }
    }
}

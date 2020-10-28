using Microsoft.Data.SqlClient;
using System;
using System.Globalization;
using System.Linq;

namespace _08_Increase_Minion_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            minionsDB.Open();

            string updateMinionsAgeQuery =
                $"UPDATE Minions SET Age = Age + 1 WHERE Id " +
                $"IN({string.Join(", ", ids)})";

            string setMinoinsNameToTitleCaseQuery =
                $"UPDATE Minions SET[Name] = " +
                $"UPPER(LEFT([Name], 1))+LOWER" +
                $"(SUBSTRING([Name], 2, LEN([Name]))) " +
                $"WHERE Id IN({string.Join(", ", ids)})";

            var updateAge = new SqlCommand(updateMinionsAgeQuery, minionsDB);
            updateAge.ExecuteNonQuery();

            var setNamesToTitle = new SqlCommand(setMinoinsNameToTitleCaseQuery, minionsDB);
            setNamesToTitle.ExecuteNonQuery();

            string getMinionsQuery = "SELECT [Name], Age FROM Minions";
            var getMinionsCmd = new SqlCommand(getMinionsQuery, minionsDB);

            SqlDataReader reader = getMinionsCmd.ExecuteReader();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];

                Console.WriteLine($"{minionName} {minionAge}");
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05_Change_Town_Names_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            minionsDB.Open();
            int countryId = GetCountryId(country, minionsDB);
            int updatedRows = ChangeTownCase(minionsDB, countryId);

            if (updatedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            SqlCommand getChangetTownsCmd = GetChangetTowns(minionsDB, countryId);

            using SqlDataReader reader = getChangetTownsCmd.ExecuteReader();

            List<string> towns = new List<string>();

            while (reader.Read())
            {
                string townName = (string)reader["Name"];
                towns.Add(townName);
            }

            Console.WriteLine($"{updatedRows} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", towns)}]");
        }

        private static SqlCommand GetChangetTowns(SqlConnection minionsDB, int countryId)
        {
            string getChangedCaseTownsQuery =
                            @"SELECT [Name] FROM Towns
                     WHERE CountryCode = @CountryCode";
            SqlCommand getChangetTownsCmd = new SqlCommand(getChangedCaseTownsQuery, minionsDB);
            getChangetTownsCmd.Parameters
                .AddWithValue("@CountryCode", countryId);
            return getChangetTownsCmd;
        }

        private static int ChangeTownCase(SqlConnection minionsDB, int countryId)
        {
            string changeCaseQuery =
                            @"UPDATE Towns
                    SET [Name] = UPPER([Name])
                    WHERE CountryCode = @CountryCode";
            SqlCommand changeCaseCmd =
                new SqlCommand(changeCaseQuery, minionsDB);
            changeCaseCmd.Parameters
                .AddWithValue("@CountryCode", countryId);
            int updatedRows = changeCaseCmd.ExecuteNonQuery();
            return updatedRows;
        }

        private static int GetCountryId(string country, SqlConnection minionsDB)
        {
            string getCountryIdQuery =
                            @"SELECT Id FROM Countries 
                    WHERE [Name] = @CountryName";

            SqlCommand getCountryIdCmd =
                new SqlCommand(getCountryIdQuery, minionsDB);
            getCountryIdCmd.Parameters
                .AddWithValue("@CountryName", country);
            int countryId = (int)getCountryIdCmd.ExecuteScalar();
            return countryId;
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07_Print_All_Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            minionsDB.Open();

            string getMinionNamesQuery =
                "SELECT [Name] From Minions ORDER By id";
            SqlCommand getMinionNames = new SqlCommand(getMinionNamesQuery, minionsDB);

            using SqlDataReader reader = getMinionNames.ExecuteReader();

            List<string> minionNames = new List<string>();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];

                minionNames.Add(minionName);
            }

            List<string> freakSort = new List<string>();

            FreakSort(minionNames, freakSort);

            Console.WriteLine(string.Join(Environment.NewLine, freakSort));
        }

        private static void FreakSort(List<string> minionNames, List<string> freakSort)
        {
            while (minionNames.Count > 0)
            {
                freakSort.Add(minionNames[0]);

                if ((minionNames.Count) > 1)
                {
                    freakSort.Add(minionNames[minionNames.Count - 1]);
                }

                if (minionNames.Count > 0)
                {
                    minionNames.RemoveAt(0);
                }

                if (minionNames.Count > 0)
                {
                    minionNames.RemoveAt(minionNames.Count - 1);
                }
            }
        }
    }
}

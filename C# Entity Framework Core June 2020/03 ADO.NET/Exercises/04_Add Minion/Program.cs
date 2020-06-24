using Microsoft.Data.SqlClient;
using System;

namespace _04_Add_Minion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInput = Console.ReadLine().Split(": ");
            string[] minionInfo = minionInput[1].Split(" ");

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            string[] villainInput = Console.ReadLine().Split(": ");

            string villainName = villainInput[1];

            using SqlConnection minionsDB = new SqlConnection(TextQueries.ConnsectionString);
            minionsDB.Open();

            string findTownQuery = TextQueries.FindTownQuery;

            SqlCommand getTownCommand = new SqlCommand(findTownQuery, minionsDB);
            getTownCommand.Parameters.AddWithValue("@Name", minionTown);

            string townName = getTownCommand.ExecuteScalar() as string;

            if (townName == null)
            {
                AddTownToDb(minionTown, minionsDB);
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            string findVillainQuery = TextQueries.FindVillainQuery;

            var getVillain = new SqlCommand(findVillainQuery, minionsDB);
            getVillain.Parameters.AddWithValue("@Name", villainName);

            string villain = getVillain.ExecuteScalar() as string;

            if (villain == null)
            {
                AddVillainToDb(minionsDB, villainName);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            string getTownIdQuery = "";

            AddNewMinionToDb(minionName, minionAge, minionTown, minionsDB);

            int minionIdToAdd = GetMinionId(minionName, minionsDB);
            int villainIdToAdd = GetVillainId(minionsDB, villain);

            SetMinionToVillain(minionsDB, minionIdToAdd, villainIdToAdd);
            Console.WriteLine($"Successfully added {minionName} to be minion of {villain}.");
        }

        private static void AddNewMinionToDb(string minionName, int minionAge, string minionTown, SqlConnection minionsDB)
        {
            string addNewMinionToDb = TextQueries.AddNewMinionToDb;
            var addMinionToDb = new SqlCommand(addNewMinionToDb, minionsDB);
            addMinionToDb.Parameters.AddWithValue("@Name", minionName);
            addMinionToDb.Parameters.AddWithValue("@Age", minionAge);
            addMinionToDb.Parameters.AddWithValue("@TownId", minionTown);//***TownId!!!!
            addMinionToDb.ExecuteNonQuery();
        }

        private static void SetMinionToVillain(SqlConnection minionsDB, int minionIdToAdd, int villainIdToAdd)
        {
            string setMinionToVillainQuery = TextQueries.SetMinionToVillain;
            var addMinionToVillainCommand = new SqlCommand(setMinionToVillainQuery, minionsDB);
            addMinionToVillainCommand.Parameters.
                AddWithValue("@MinionId", minionIdToAdd);
            addMinionToVillainCommand.Parameters.
                AddWithValue("@VillainId", villainIdToAdd);
            addMinionToVillainCommand.ExecuteNonQuery();
        }

        private static int GetVillainId(SqlConnection minionsDB, string villain)
        {
            string getVillainIdQuery = TextQueries.GetVillainId;
            var getVillainIdCommand = new SqlCommand(getVillainIdQuery, minionsDB);
            getVillainIdCommand.Parameters.AddWithValue("@VillainName", villain);
            int villainIdToAdd = (int)getVillainIdCommand.ExecuteScalar();
            return villainIdToAdd;
        }

        private static int GetMinionId(string minionName, SqlConnection minionsDB)
        {
            string getMinionIdQuery = TextQueries.GetMinionId;
            var getMinionIdCommand = new SqlCommand(getMinionIdQuery, minionsDB);
            getMinionIdCommand.Parameters.AddWithValue("@MinionName", minionName);
            int minionToAddId = (int)getMinionIdCommand.ExecuteScalar();
            return minionToAddId;
        }

        private static void AddVillainToDb(SqlConnection minionsDB, string villain)
        {
            string addVillainQuery = TextQueries.AddVillainQuery;
            var addVillainCommand = new SqlCommand(addVillainQuery, minionsDB);
            addVillainCommand.Parameters.AddWithValue("@VillainName", villain);
            addVillainCommand.ExecuteNonQuery();
        }

        private static void AddTownToDb(string minionTown, SqlConnection minionsDB)
        {
            string addTownQuery = TextQueries.AddTownQuery;
            var addTownCommand = new SqlCommand(addTownQuery, minionsDB);
            addTownCommand.Parameters.AddWithValue("@TownName", minionTown);
            addTownCommand.ExecuteNonQuery();
        }
    }
}

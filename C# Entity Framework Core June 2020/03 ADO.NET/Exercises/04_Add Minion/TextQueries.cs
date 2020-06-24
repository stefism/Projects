using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Add_Minion
{
    public static class TextQueries
    {
        public const string ConnsectionString = @"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        public const string FindTownQuery = "SELECT [Name] FROM Towns WHERE [Name] = @Name";

        public const string FindVillainQuery = "SELECT [Name] FROM Villains WHERE [Name] = @Name";

        public const string AddTownQuery = "INSERT INTO Towns VALUES (@TownName, NULL)";

        public const string AddVillainQuery = "INSERT INTO Villains VALUES (@VillainName, 4)";

        public const string AddNewMinionToDb = "INSERT INTO Minions VALUES(@Name, @Age, @TownId)";

        public static string SetMinionToVillain = "INSERT INTO MinionsVillains VALUES(@MinionId, @VillainId)";

        public static string GetVillainId = "SELECT Id FROM Villains WHERE [Name] = @VillainName";

        public static string GetMinionId = "SELECT Id FROM Minions WHERE [Name] = @MinionName";

        public static string GetTownId = "SELECT Id FROM Towns WHERE [Name] = @TownName";
    }
}

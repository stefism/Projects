using Microsoft.Data.SqlClient;
using System;

namespace _01_Initial_Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            //using SqlConnection minionsDBCreate = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=master;Integrated Security=true");
            
            //minionsDBCreate.Open();
            //SqlCommand createMinons = new SqlCommand("CREATE DATABASE MinionsDB", minionsDBCreate);
            //createMinons.ExecuteNonQuery();

            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");
            
            minionsDB.Open();

            #region CreateTables
            string createTables =
                @"CREATE TABLE Countries
                (
                   Id INT PRIMARY KEY IDENTITY NOT NULL,
                   [Name] NVARCHAR(100)
                )
                
                CREATE TABLE Towns
                (
                   Id INT PRIMARY KEY IDENTITY NOT NULL,
                   [Name] NVARCHAR(100),
                   CountryCode INT FOREIGN KEY REFERENCES Countries(Id)
                )
                
                CREATE TABLE Minions
                (
                   Id INT PRIMARY KEY IDENTITY NOT NULL,
                   [Name] NVARCHAR(100) NOT NULL,
                   Age INT,
                   TownId INT FOREIGN KEY REFERENCES Towns(Id)
                )
                
                CREATE TABLE EvilnessFactors
                (
                Id INT PRIMARY KEY IDENTITY NOT NULL,
                [Name] NVARCHAR(100)
                )
                
                CREATE TABLE Villains
                (
                Id INT PRIMARY KEY IDENTITY NOT NULL,
                [Name] NVARCHAR(100),
                EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id)
                )
                
                CREATE TABLE MinionsVillains
                (
                	MinionId INT NOT NULL,
                	VillainId INT NOT NULL
                )
                
                ALTER TABLE MinionsVillains
                ADD CONSTRAINT PK_MinionId_VillainId
                PRIMARY KEY(MinionId, VillainId)
                
                ALTER TABLE MinionsVillains
                ADD CONSTRAINT FK_MinionId
                FOREIGN KEY(MinionId) REFERENCES Minions(Id)
                
                ALTER TABLE MinionsVillains
                ADD CONSTRAINT FK_VillainId
                FOREIGN KEY(VillainId) REFERENCES Villains(Id)";
            #endregion

            SqlCommand createTablesCommand = new SqlCommand(createTables, minionsDB);
            createTablesCommand.ExecuteNonQuery();
        }
    }
}

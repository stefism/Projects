using System;
using System.Data.SqlClient;
using System.Text;

namespace _01_InitialSetup
{
    class Program
    {
        private static string connString =
            @"Server=STEFCHO\SQLEXPRESS;
                Database={0};
                Integrated Security=true";

        static void Main(string[] args)
        {
            SqlConnection connection = 
                new SqlConnection(string.Format(connString, "master"));

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand
                    ("CREATE DATABASE MinionsDB", connection);

                command.ExecuteNonQuery();
            }

            connection = new SqlConnection(string.Format(connString, "MinionsDB"));

            connection.Open();

            string createTables = CreateTablesForMinionsDB();
            string fillTables = FillTablesForMinionsDb();

            using (connection)
            {
                SqlCommand createTablesForMinionsDb 
                    = new SqlCommand(createTables, connection);

                SqlCommand fillTablesForMinionDb
                    = new SqlCommand(fillTables, connection);

                createTablesForMinionsDb.ExecuteNonQuery();
                fillTablesForMinionDb.ExecuteNonQuery();
            }

            Console.WriteLine("All is OK :)");
        }

        static string FillTablesForMinionsDb()
        {
            StringBuilder fillTables = new StringBuilder();

            fillTables.AppendLine("INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')")
                .AppendLine("INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)")
                .AppendLine("INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)")
                .AppendLine("INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')")
                .AppendLine("INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)")
                .AppendLine("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)");

            return fillTables.ToString();
        }
        static string CreateTablesForMinionsDB() 
        {
            StringBuilder createTables = new StringBuilder();

            createTables.AppendLine("CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))")
                .AppendLine("CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))")
                .AppendLine("CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))")
                .AppendLine("CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))")
                .AppendLine("CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))")
                .AppendLine("CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))");

            return createTables.ToString();
        }
    }
}

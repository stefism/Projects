using Microsoft.Data.SqlClient;
using System;

namespace _09_Increase_Age_Stored_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            minionsDB.Open();
            CreateProcedureIfNotExist(minionsDB);

            Console.Write("Inisert Minion Id: ");
            int minionId = int.Parse(Console.ReadLine());

            string callProcQuery = $"EXEC usp_GetOlder {minionId}";
            SqlCommand callProcCmd = new SqlCommand(callProcQuery, minionsDB);
            callProcCmd.ExecuteNonQuery();

            string getMinionInfoQuery = 
                @"SELECT [Name], Age 
                    FROM Minions
                    WHERE Id = @MinionId";
            SqlCommand getMinionInfoCmd = 
                new SqlCommand(getMinionInfoQuery, minionsDB);
            getMinionInfoCmd.Parameters.AddWithValue("@MinionId", minionId);

            using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();
            reader.Read();
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];

            Console.WriteLine($"{minionName} – {minionAge} years old");
        }

        private static void CreateProcedureIfNotExist(SqlConnection minionsDB)
        {
            const string ProcedureName = "usp_GetOlder";

            string isProcedureExistQuery =
                @"SELECT COUNT(*) 
                 FROM MinionsDB.INFORMATION_SCHEMA.ROUTINES
                 WHERE ROUTINE_TYPE  =  'PROCEDURE' 
                AND SPECIFIC_NAME  =  @ProcedureName";

            SqlCommand isProcedureExistCmd = new SqlCommand(isProcedureExistQuery, minionsDB);
            isProcedureExistCmd.Parameters.
                AddWithValue("@ProcedureName", ProcedureName);

            int procCount = (int)isProcedureExistCmd.ExecuteScalar();

            if (procCount == 0)
            {
                string storeProcedureQuery =
                    @"CREATE PROC usp_GetOlder(@MinionId INT)
                        AS
                        	UPDATE Minions
                        	SET Age = Age + 1
                        	WHERE Id = @MinionId";

                SqlCommand createProcCmd = new SqlCommand(storeProcedureQuery, minionsDB);
                createProcCmd.ExecuteNonQuery();

                Console.WriteLine("User stored procedure usp_GetOlder created succesfull in database MinionsDB");
            }
        }
    }
}

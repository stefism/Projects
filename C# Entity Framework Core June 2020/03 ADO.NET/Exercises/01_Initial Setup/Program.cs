using Microsoft.Data.SqlClient;
using System;

namespace _01_Initial_Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection minionsDBCreate = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=master;Integrated Security=true");

            minionsDBCreate.Open();
            SqlCommand createMinons = new SqlCommand("CREATE DATABASE MinionsDB", minionsDBCreate);
            createMinons.ExecuteNonQuery();

            using SqlConnection minionsDB = new SqlConnection(@"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");
            
            minionsDB.Open();

            string createTables = TextQueries.CreateTables;

            string fillTablesWithData = TextQueries.FillTableWithData;
                           
            SqlCommand createTablesCommand = 
                new SqlCommand(createTables, minionsDB);
            createTablesCommand.ExecuteNonQuery();

            SqlCommand fillTableCmd = 
                new SqlCommand(fillTablesWithData, minionsDB);
            fillTableCmd.ExecuteNonQuery();
        }
    }
}

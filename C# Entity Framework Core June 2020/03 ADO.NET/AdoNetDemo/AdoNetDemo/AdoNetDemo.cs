using Microsoft.Data.SqlClient;
using System;

namespace AdoNetDemo
{
    class AdoNetDemo
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=SoftUni;Integrated Security=true";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string command = "SELECT COUNT(*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                int result = (int)sqlCommand.ExecuteScalar();
                //ExecuteScalar връща object и трябва после да се кастне.
                Console.WriteLine(result);

                string command2 = " SELECT * FROM Employees WHERE FirstName LIKE 'N%' ";
                SqlCommand sqlCommand2 = new SqlCommand(command2, sqlConnection);

                using (SqlDataReader reader = sqlCommand2.ExecuteReader()) // Ридера задължително също в узинг.
                {
                    while (reader.Read()) // Докато ридера чете, чети редовете ред по ред.
                    {
                        string firstName = (string)reader[1];
                        // reader[1] - втората колона от таблицата, която е съответно firstName (броим от нула). Понеже отново не знае какъв е типа на колоната и затова отново връща object и трябва да го кастнем.
                        string lastName = (string)reader["LastName"];
                        // Можем вместо индекс да пишем и точните имена на колоните.
                        Console.WriteLine(firstName + " " + lastName);
                    }
                }
                    
               //SqlCommand updateSalaryCommand = new SqlCommand("UPDATE Employees SET //Salary = Salary * 1.10", sqlConnection);
               //int updatedRows = updateSalaryCommand.ExecuteNonQuery();
               //Console.WriteLine($"Salary updated for {updatedRows} employees.");
            }
        }
    }
}

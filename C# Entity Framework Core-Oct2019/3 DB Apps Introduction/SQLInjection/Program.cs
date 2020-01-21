using System;
using System.Data.SqlClient;

namespace SQLInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection
                (@"Server=STEFCHO\SQLEXPRESS;Database=SoftUni;Integrated Security=True;");

            connection.Open();

            string firstName = "Kevin";
            string stringZaHakvane = "' OR 1=1 --'";

            using (connection)
            {
                SqlCommand command = new SqlCommand
                   ($"SELECT * FROM Employees WHERE FirstName = '{firstName}'", connection); // Така не се прави!

                SqlCommand command2 = new SqlCommand
                   ($"SELECT * FROM Employees WHERE FirstName = '{stringZaHakvane}'", connection); // Така може да се хакне базата. Заявката ще върне всички данни от базата.

                SqlCommand command3 = new SqlCommand
                   ($"SELECT * FROM Employees WHERE FirstName = @name", connection); // Защитата е като се сложат параметри в заявките -> @name
                
                command3.Parameters.AddWithValue("@name", firstName); // Казваме - към тази команда, добави този параметър. Всеки парамерът се вкарва (подава) отделно към командата.
            }
        }
    }
}

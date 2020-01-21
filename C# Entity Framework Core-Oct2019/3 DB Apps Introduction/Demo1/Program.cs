using System;
using System.Data.SqlClient;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection
                (@"Server=STEFCHO\SQLEXPRESS;Database=SoftUni;Integrated Security=True;");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand
                    ("SELECT COUNT(*) FROM Employees", connection);

                SqlCommand command2 = new SqlCommand
                    ("SELECT * FROM Employees", connection);

                var result2 = command2.ExecuteScalar();
                //ще даде резултат "1". Това е на първи ред, първата колона, или ай ди то на първия записан в таблицата.

                var result = command.ExecuteScalar(); // Дава на първи ред, първата колона. Result е от тип Object и ако искаме да го ползваме за нещо специфично, трябва да го кастнем.

                var reader = command2.ExecuteReader();

                using (reader) // Ридера също се слага в юзинг.
                {
                    while (reader.Read()) // Докато има какво да четеш ...
                    {
                        Console.WriteLine(reader[1] + " " + reader[2]); // Нула е първата колона от таблицата, Едно втората и т.н. Всеки Read минава на нов ред. Можем в квадратните скоби да даваме и името на колоната -> reader["FirstName"].
                    }
                }

                    //Console.WriteLine(result);
            }
        }
    }
}

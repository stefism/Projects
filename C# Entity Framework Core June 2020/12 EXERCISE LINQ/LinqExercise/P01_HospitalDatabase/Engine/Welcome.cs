using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Engine
{
    public static class Welcome
    {
        public static int LoginOrRegister()
        {
            Console.WriteLine("Добре дошли в докторската система.");
            Console.WriteLine("Моля изберете:");
            Console.WriteLine("1. Логин в системата.");
            Console.WriteLine("2. Регистрация на нов потребител.");

            int options = int.Parse(Console.ReadLine());
            return options;
        }
    }
}

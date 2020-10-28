using P01_HospitalDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_HospitalDatabase.Engine
{
    public static class LoginInSystem
    {
        public static void Login()
        {
            Console.WriteLine("Моля въведете данни за логин в системата:");
            Console.Write("Потребителско име: ");
            string username = Console.ReadLine();

            Console.Write("Парола: ");
            string password = Console.ReadLine();

            var db = new HospitalContext();

            var doctor = db.Doctors
                .Where(d => d.UserName == username)
                .FirstOrDefault();

            bool isPasswordValid = HashPassword.IsPasswordValid(password, doctor.Password);

            if (isPasswordValid)
            {
                Console.WriteLine($"Добре дошли доктор {doctor.Name}");
            }
            else
            {
                Console.WriteLine("Невалидна парола.");
            }
        }
    }
}

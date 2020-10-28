using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Engine;
using System;
using System.Linq;

namespace P01_HospitalDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int options = Welcome.LoginOrRegister();

            if (options == 1)
            {
                LoginInSystem.Login();
            }
            else if (options == 2)
            {
                RegisterDoctor.Register();
            }
            else
            {
                Console.WriteLine("Невалиден избор!");
            }
        }
    }
}

using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_HospitalDatabase.Engine
{
    public static class RegisterDoctor
    {
        public static  void Register()
        {
            Console.Write("Име на лекаря: ");
            string doctorName = Console.ReadLine();

            Console.Write("Специалност: ");
            string specialty = Console.ReadLine();

            Console.Write("Потребителско име (на латиница): ");
            string userName = Console.ReadLine();

            Console.Write("Парола (на латиница): ");
            string password = Console.ReadLine();
            string hashPassword = HashPassword.HashPass(password);

            var db = new HospitalContext();

            var newDoctor = new Doctor
            {
                Name = doctorName,
                Specialty = specialty,
                UserName = userName,
                Password = hashPassword
            };
            
            db.Doctors.Add(newDoctor);
            db.SaveChanges();

            Console.WriteLine("Регистрацията премина успешно.");
            Console.WriteLine("В базата е добавен следния потребител:");

            var addedDoctor = db.Doctors
                .Where(d => d.UserName == userName)
                .Select(d => new
                {
                    d.DoctorId,
                    d.Name,
                    d.Specialty,
                    d.UserName
                }).FirstOrDefault();

            Console.WriteLine($"Доктор ИД: {addedDoctor.DoctorId}");
            Console.WriteLine($"Име: {addedDoctor.Name}");
            Console.WriteLine($"Специалност: {addedDoctor.Specialty}");
            Console.WriteLine($"Потребителско име: {addedDoctor.UserName}");
            Console.WriteLine("Парола: ааа-а. Не се показва! Дано сте я запомнили :D");
        }
    }
}

using CodeFirstDemo.Data;
using CodeFirstDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirstDemo
{
    public class Program
    {
        // ** Необходими пакети:
        // 1. Microsoft.EntityFrameworkCore.SqlServer
        // 2. Microsoft.EntityFrameworkCore.Tools

        // Стъпки за създаване на база:
        // 1. Добавяме модели (класове) -> Srudent
        // 2. Primary Key -> Id
        // 3. Добавяме останалите колони за съответната таблица (клас).
        // 4. Анотации -> maxLength, Required ect. Задължително на стринговете слагаме maxLength иначе стават големи VARCHAR и NVARCHAR.
        // 5. Добавяме DbContex + DbSet за всеки модел (клас).
        // 6. OnConfiguring - в него се слага connection string-а
        // 7. OnModelCreating -> описваме връзките между таблиците (класовете).
        // 8. Не забравяме навигационните пропертита, за да са ни по-лесни заявките.
        // 9. Many-toMany - две One-to-Many + .HasKey(sc => new {sc.firstKeyId, sc.SecondKeyId}).
        // 10. Правим миграцията -> Add-Migration {MigrationName}
        // 11. db.Database.Migrate();
        // 12. Queries :)

        public static void Main(string[] args)
        {
            using var db = new StudentsDbContext();

            db.Database.Migrate();

            // Всички курсове (имената на курсовете), за всеки курс - бройката студенти и всички студенти, заедно с техните оценки от домашните;
            var couses = db.Courses
                .Select(c => new
                {
                    c.Name,
                    TotalStudents = c.Students
                                            .Where(st => st.Course.Homeworks.Average(h => h.Score) > 2)
                                            .Count(),
                    Students = c.Students
                    .Select(st => new 
                    {
                        FullName = st.Student.FirstName + " " + st.Student.LastName,
                        Score = st.Student.Homeworks.Average(h => h.Score)
                    })
                }).ToList();
        }
    }
}

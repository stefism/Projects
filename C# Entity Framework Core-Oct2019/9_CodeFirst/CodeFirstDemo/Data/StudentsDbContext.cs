using CodeFirstDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstDemo.Data
{
    public class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<StudentInCourse> StudentsInCourses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConnection);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>() // Единицата студент
                .HasOne(st => st.Town) // Има един град
                .WithMany(t => t.Students) // А един град, има много студенти
                .HasForeignKey(st => st.TownId); // И се посочва колоната, която е форен кий.

            modelBuilder.Entity<Student>()
                .HasMany(st => st.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentID);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);

            modelBuilder.Entity<StudentInCourse>()
                .HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId
                }); // При мапинг таблица, първо трябва да укажем, че имаме композитен ключ, който е и от двете пропертита.

            modelBuilder.Entity<StudentInCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(sc => sc.Courses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentInCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(sc => sc.Students)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}

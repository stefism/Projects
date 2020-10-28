using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity
                    .Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode();

                entity
                    .Property(s => s.PhoneNumber)
                    .IsUnicode(false)
                    .IsRequired(false)
                    .HasMaxLength(10);

                entity
                    .Property(s => s.RegisteredOn)
                    .IsRequired();


            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(80);

                entity
                    .Property(c => c.Description)
                    .IsUnicode()
                    .IsRequired(false);

                entity
                    .Property(c => c.StartDate)
                    .IsRequired();

                entity.Property(c => c.EndDate)
                    .IsRequired();

                entity
                    .Property(c => c.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity
                    .Property(r => r.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(r => r.Url)
                    .IsUnicode(false);

                entity
                    .HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity
                    .Property(h => h.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity
                    .HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

                entity
                    .HasOne(h => h.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(ps => new {ps.StudentId,ps.CourseId});

                entity
                    .HasOne(ps => ps.Student)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(ps => ps.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(p => p.Course)
                    .WithMany(g => g.StudentsEnrolled)
                    .HasForeignKey(p => p.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

             //.HasOne(t => t.PrimaryKitColor)
            //.WithMany(c => c.PrimaryKitTeams)
            //.HasForeignKey(t => t.PrimaryKitColorId)
    }
}

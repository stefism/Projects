using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ModelConf
{
    public class StudentCourseConf : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> studentCourses)
        {
            studentCourses.HasKey(sc => new
            {
                sc.StudentId,
                sc.CourseId
            });

            studentCourses.HasOne(sc => sc.Course)
                                  .WithMany(c => c.StudentCourses)
                                  .HasForeignKey(sc => sc.CourseId)
                                  .OnDelete(DeleteBehavior.Restrict);

            studentCourses.HasOne(sc => sc.Student)
                                  .WithMany(s => s.StudentCourses)
                                  .HasForeignKey(sc => sc.StudentId)
                                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

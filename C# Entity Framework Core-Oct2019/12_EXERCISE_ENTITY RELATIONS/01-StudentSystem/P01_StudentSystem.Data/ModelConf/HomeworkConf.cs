using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ModelConf
{
    public class HomeworkConf : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> homework)
        {
            homework.HasKey(h => h.HomeworkId);

            homework.Property(h => h.Content)
                           .HasMaxLength(200)
                           .IsRequired(true)
                           .IsUnicode(false);

            homework.Property(h => h.ContentType)
                           .IsRequired(true);

            homework.Property(h => h.SubmissionTime)
                           .IsRequired(true);

            homework.HasOne(h => h.Course)
                           .WithMany(c => c.HomeworkSubmissions)
                           .HasForeignKey(h => h.CourseId)
                           .OnDelete(DeleteBehavior.Restrict);

            homework.HasOne(h => h.Student)
                           .WithMany(s => s.HomeworkSubmissions)
                           .HasForeignKey(h => h.StudentId)
                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System.Linq;

namespace P01_StudentSystem.Data.ModelConf
{
    public class StudentConf : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student.HasKey(s => s.StudentId);

            student.Property(s => s.Name)
                       .HasMaxLength(100)
                       .IsRequired(true)
                       .IsUnicode(true);

            student.Property(s => s.PhoneNumber)
                       .HasMaxLength(10)
                       .IsFixedLength()
                       .IsUnicode(false)
                       .IsRequired(false);

            student.Property(s => s.RegisteredOn)
                       .IsRequired(true);

            student.Property(s => s.Birthday)
                       .IsRequired(false);
        }
    }
}

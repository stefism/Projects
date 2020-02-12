using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ModelConf
{
    public class ResourceConf : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource.HasKey(r => r.ResourceId);

            resource.Property(r => r.Name)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);

            resource.Property(r => r.Url)
                        .HasMaxLength(500)
                        .IsRequired(true)
                        .IsUnicode(false);

            resource.Property(r => r.ResourceType)
                        .IsRequired(true);

            resource.HasOne(r => r.Course)
                        .WithMany(c => c.Resources)
                        .HasForeignKey(r => r.CourseId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

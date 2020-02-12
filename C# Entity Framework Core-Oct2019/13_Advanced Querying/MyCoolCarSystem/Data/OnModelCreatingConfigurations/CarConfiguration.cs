using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoolCarSystem.Data.Models;

namespace MyCoolCarSystem.Data.OnModelCreatingConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car
                      .HasOne(c => c.Model)
                      .WithMany(m => m.Cars)
                      .HasForeignKey(c => c.ModelId)
                      .OnDelete(DeleteBehavior.Restrict);

            car
                      .HasIndex(c => c.Vin)
                      .IsUnique();
        }
    }
}

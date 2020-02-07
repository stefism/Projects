using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoolCarSystem.Data.Models;

namespace MyCoolCarSystem.Data.OnModelCreatingConfigurations
{
    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
                     .HasMany(m => m.Models)
                     .WithOne(m => m.Make)
                     .HasForeignKey(m => m.MakeId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

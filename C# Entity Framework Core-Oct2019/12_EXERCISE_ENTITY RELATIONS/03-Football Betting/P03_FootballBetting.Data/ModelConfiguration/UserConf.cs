using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user.Property(u => u.Balance)
                  .IsRequired(true);

            user.Property(u => u.Email)
                  .HasMaxLength(50)
                  .IsRequired(true)
                  .IsUnicode(false);

            user.Property(u => u.Name)
                  .HasMaxLength(50)
                  .IsRequired(true)
                  .IsUnicode(true);

            user.Property(u => u.Password)
                  .HasMaxLength(30)
                  .IsRequired(true)
                  .IsUnicode(true);

            user.Property(u => u.Username)
                  .HasMaxLength(50)
                  .IsRequired(true)
                  .IsUnicode(true);
        }
    }
}

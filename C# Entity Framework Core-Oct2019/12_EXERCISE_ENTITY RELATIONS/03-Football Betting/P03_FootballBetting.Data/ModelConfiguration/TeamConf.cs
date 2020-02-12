using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class TeamConf : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        {
            team.HasKey(t => t.TeamId);

            team.Property(t => t.Name)
                   .HasMaxLength(50)
                   .IsRequired(true)
                   .IsUnicode(true);

            team.Property(t => t.LogoUrl)
                   .HasMaxLength(500)
                   .IsRequired(false)
                   .IsUnicode(false)
                   .HasDefaultValue("None");

            team.Property(t => t.Initials)
                   .HasMaxLength(10)
                   .IsRequired(true)
                   .IsUnicode(true);

            team.Property(t => t.Budget)
                   .IsRequired(true);

            team.HasOne(t => t.PrimaryKitColor)
                   .WithMany(c => c.PrimaryKitTeams)
                   .HasForeignKey(t => t.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            team.HasOne(t => t.SecondaryKitColor)
                   .WithMany(c => c.SecondaryKitTeams)
                   .HasForeignKey(t => t.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            team.HasOne(tm => tm.Town)
                   .WithMany(tw => tw.Teams)
                   .HasForeignKey(tm => tm.TownId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class PlayerConf : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> player)
        {
            player.HasKey(p => p.PlayerId);

            player.Property(p => p.Name)
                     .HasMaxLength(100)
                     .IsRequired(true)
                     .IsUnicode(true);

            player.Property(p => p.IsInjured)
                     .IsRequired(true);

            player.Property(p => p.SquadNumber)
                     .HasMaxLength(10)
                     .IsRequired(true)
                     .IsUnicode(false);

            player.HasOne(p => p.Team)
                     .WithMany(t => t.Players)
                     .HasForeignKey(p => p.TeamId);

            player.HasOne(pl => pl.Position)
                     .WithMany(p => p.Players)
                     .HasForeignKey(pl => pl.PositionId);


        }
    }
}

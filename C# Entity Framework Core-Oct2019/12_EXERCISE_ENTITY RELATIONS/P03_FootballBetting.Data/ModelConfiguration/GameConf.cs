using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class GameConf : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game.HasKey(g => g.GameId);

            game.Property(g => g.AwayTeamBetRate)
                    .HasMaxLength(10)
                    .IsRequired(false)
                    .IsUnicode(true)
                    .HasDefaultValue("None");

            game.Property(g => g.HomeTeamBetRate)
                    .HasMaxLength(10)
                    .IsRequired(false)
                    .IsUnicode(true)
                    .HasDefaultValue("None");

            game.Property(g => g.DrawBetRate)
                    .HasMaxLength(10)
                    .IsRequired(false)
                    .IsUnicode(true)
                    .HasDefaultValue("None");

            game.Property(g => g.AwayTeamGoals)
                    .IsRequired(true)
                    .HasDefaultValue(0);

            game.Property(g => g.HomeTeamGoals)
                    .IsRequired(true)
                    .HasDefaultValue(0);

            game.Property(g => g.Result)
                    .HasMaxLength(10)
                    .IsRequired(false)
                    .IsUnicode(true)
                    .HasDefaultValue("None");

            game.Property(g => g.DateTime)
                    .IsRequired(true)
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()");

            game.HasMany(g => g.Bets)
                    .WithOne(b => b.Game)
                    .HasForeignKey(b => b.GameId);

            game.HasMany(g => g.PlayerStatistics)
                    .WithOne(ps => ps.Game)
                    .HasForeignKey(ps => ps.GameId);
        }
    }
}

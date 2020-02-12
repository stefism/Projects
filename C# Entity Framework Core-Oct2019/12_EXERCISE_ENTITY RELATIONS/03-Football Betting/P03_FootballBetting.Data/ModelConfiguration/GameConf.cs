﻿using System;
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
                    .IsRequired(true);

            game.Property(g => g.HomeTeamBetRate)
                    .IsRequired(true);

            game.Property(g => g.DrawBetRate)
                    .IsRequired(true);

            game.Property(g => g.AwayTeamGoals)
                    .IsRequired(true);

            game.Property(g => g.HomeTeamGoals)
                    .IsRequired(true);

            game.Property(g => g.Result)
                    .HasMaxLength(10)
                    .IsRequired(true)
                    .IsUnicode(false);

            game.Property(g => g.DateTime)
                    .IsRequired(true);

            game.HasOne(g => g.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

            game.HasOne(g => g.AwayTeam)
                    .WithMany(at => at.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

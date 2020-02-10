using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class PlayerStatisticConf : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> playerStatistic)
        {
            playerStatistic.HasKey(ps => new
            {
                ps.PlayerId,
                ps.GameId
            });

            playerStatistic.Property(ps => ps.Assists)
                                .IsRequired(true)
                                .HasDefaultValue(0);

            playerStatistic.Property(ps => ps.ScoredGoals)
                                .IsRequired(true)
                                .HasDefaultValue(0);

            playerStatistic.Property(ps => ps.MinutesPlayed)
                                .IsRequired(true)
                                .HasDefaultValue(0.0);
        }
    }
}

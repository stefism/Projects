using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class BetConf : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet.HasKey(b => b.BetId);

            bet.Property(b => b.Amount)
                 .IsRequired(true);

            bet.Property(b => b.Prediction)
                 .IsRequired(true);

            bet.Property(b => b.DateTime)
                 .IsRequired(true);

            bet.HasOne(b => b.User)
                 .WithMany(u => u.Bets)
                 .HasForeignKey(b => b.UserId);

            bet.HasOne(b => b.Game)
                 .WithMany(g => g.Bets)
                 .HasForeignKey(b => b.GameId);
        }
    }
}

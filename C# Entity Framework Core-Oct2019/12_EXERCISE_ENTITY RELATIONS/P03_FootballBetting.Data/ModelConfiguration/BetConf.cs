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
                 .HasMaxLength(20)
                 .IsRequired(true)
                 .IsUnicode(true);

            bet.Property(b => b.DateTime)
                 .IsRequired(true)
                 .HasColumnType("DATETIME2")
                 .HasDefaultValueSql("GETDATE()");
        }
    }
}

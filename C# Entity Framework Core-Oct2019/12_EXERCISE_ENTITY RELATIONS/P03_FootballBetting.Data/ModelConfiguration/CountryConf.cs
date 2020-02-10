﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.ModelConfiguration
{
    public class CountryConf : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> country)
        {
            country.HasKey(c => c.CountryId);

            country.Property(c => c.Name)
                       .HasMaxLength(50)
                       .IsRequired(true)
                       .IsUnicode(true);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.ModelConfiguration;
using P03_FootballBetting.Data.Models;
using System;
using System.Reflection;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        //Install-Package Microsoft.EntityFrameworkCore -v 2.2.0
        //Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.2.0
        //Install-Package Microsoft.EntityFrameworkCore.Tools -v 2.2.0
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new BetConf());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

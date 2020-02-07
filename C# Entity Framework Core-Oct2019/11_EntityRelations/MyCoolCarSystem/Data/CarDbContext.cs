using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data.Models;
using MyCoolCarSystem.Data.OnModelCreatingConfigurations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyCoolCarSystem.Data
{
    //Install-Package Microsoft.EntityFrameworkCore -v 2.2.0
    //Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.2.0
    //Install-Package Microsoft.EntityFrameworkCore.Tools -v 2.2.0
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CarPurchase> Purchases { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            // Е те тоа ред, с рефлекшън си взима всичките класове с конфигурации от текущия проект, които наследяват IEntityTypeConfiguration интерфейса и си ги инстанцира автоматично. Това ни икономисва описването на всяка една конфигурация по отделно, както е направено по-долу.
            // Гига яко !!!

            //builder.ApplyConfiguration(new MakeConfiguration());

            //builder.ApplyConfiguration(new CarConfiguration());

            //builder.ApplyConfiguration(new CarPurchaseConfiguration());

            //builder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}

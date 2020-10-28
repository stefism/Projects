using Microsoft.EntityFrameworkCore;
using PetStore.Common;
using PetStore.Models;
using System;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext()
        {

        }

        public PetStoreDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientProduct> ClientProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.DefConnString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientProduct>()
                .HasKey(cp => new { cp.ClientID, cp.ProductId });

            modelBuilder.Entity<Product>()
                .HasAlternateKey(p => p.Name);
        }
    }
}

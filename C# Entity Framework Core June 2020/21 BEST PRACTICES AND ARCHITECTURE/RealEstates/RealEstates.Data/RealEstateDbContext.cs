using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {

        }

        public RealEstateDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<BuildingType> BuildingTypes { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>()
                .HasMany(d => d.Properties)
                .WithOne(p => p.District)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RealEstatePropertyTag>()
                .HasKey(p => new { p.PropertyId, p.TagId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-LNP1A21\SQLEXPRESS;Database=RealEstate;Integrated Security=True;");
            }
        }
    }
}

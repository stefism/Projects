namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Data;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTrip> UsersTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasKey(x => new { x.TripId, x.UserId });
        }
    }
}

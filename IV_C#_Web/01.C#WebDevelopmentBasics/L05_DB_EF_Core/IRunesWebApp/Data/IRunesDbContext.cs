
namespace IRunesWebApp.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Data.Configurations;

    public class IRunesDbContext : DbContext
    {
        
        public DbSet<User> users { get; set; }
        public DbSet<Album> albums { get; set; }
        public DbSet<Track> tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new AlbumConfig());
            modelBuilder.ApplyConfiguration(new TrackConfig());
        }
    }
}

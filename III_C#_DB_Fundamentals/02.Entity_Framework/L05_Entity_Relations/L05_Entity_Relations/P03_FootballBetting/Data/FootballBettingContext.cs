using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns{ get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

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
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(e => e.PrimaryKitColor)
                .WithMany(pc => pc.PrimaryKitTeams)
                .HasForeignKey(e => e.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(e => e.SecondaryKitColor)
                .WithMany(pc => pc.SecondaryKitTeams)
                .HasForeignKey(e => e.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(e => e.HomeTeam)
                .WithMany(ht => ht.HomeGames)
                .HasForeignKey(e => e.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(e => e.AwayTeam)
                .WithMany(at => at.AwayGames)
                .HasForeignKey(e => e.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}


namespace IRunesWebApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(true);

            builder.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.AlbumId);
        }
    }
}

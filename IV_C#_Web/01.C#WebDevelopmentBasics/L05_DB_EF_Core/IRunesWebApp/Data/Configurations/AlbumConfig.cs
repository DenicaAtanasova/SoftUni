
namespace IRunesWebApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(true);

            builder.HasMany(e => e.Tracks)
                .WithOne(t => t.Album)
                .HasForeignKey(t => t.AlbumId);
        }
    }
}


namespace IRunesWebApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Username)
                .IsRequired(true);

            builder.Property(e => e.Password)
                .IsRequired(true);

            builder.Property(e => e.Email)
                .IsRequired(true);

            builder.HasMany(e => e.Albums)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}

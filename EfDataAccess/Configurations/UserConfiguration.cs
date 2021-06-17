using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username).IsRequired();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).IsRequired();

            builder.HasMany(x => x.Posts)
                    .WithOne(y => y.User)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Ocene)
                    .WithOne(y => y.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UserUserCases)
                    .WithOne(y => y.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Komentars)
                    .WithOne(y => y.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

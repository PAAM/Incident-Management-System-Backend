using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations
{
    public class UserCredentialsConfiguration : IEntityTypeConfiguration<UserCredentials>
    {
        public void Configure(EntityTypeBuilder<UserCredentials> builder)
        {
            builder.ToTable("UserCredentials");

            builder.Property(x => x.Id);

            builder.HasKey(x => x.UserId);
            
            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsLocked)
                .HasDefaultValue(false);

            builder.Property(x => x.FailedLoginAttempts)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.LastLoginAt)
                .IsRequired(false);


            //RelationShip
            builder
                .HasOne(x => x.User)
                .WithOne(x => x.UserCredentials)
                .HasForeignKey<UserCredentials>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

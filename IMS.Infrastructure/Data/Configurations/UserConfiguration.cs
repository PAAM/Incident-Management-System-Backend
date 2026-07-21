using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmployeCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(x=>x.EmployeCode)
                .IsUnique();

            builder.Property(x=>x.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.SecondName)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);  

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            //Relationship
            builder
                .HasOne(x => x.Area)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations
{
    public class PriorityConfiguration: IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            //Table Name
            builder.ToTable("Priorities");

            //PK
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Description)
                    .HasMaxLength(500);

            builder.Property(x => x.IsActive);
                
        }
    }
}

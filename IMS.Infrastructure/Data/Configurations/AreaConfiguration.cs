using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Areas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AreaCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => x.AreaCode)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.IsActive);
          

        }
    }
}

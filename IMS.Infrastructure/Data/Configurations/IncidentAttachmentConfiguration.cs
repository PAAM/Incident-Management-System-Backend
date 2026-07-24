using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Data.Configurations
{
    public class IncidentAttachmentConfiguration : IEntityTypeConfiguration<IncidentAttachment>
    {
        public void Configure(EntityTypeBuilder<IncidentAttachment> builder)
        {
            builder.ToTable("IncidentAttachments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IncidentNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(x => x.IncidentNumber);
                
            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.FileSize)
                .IsRequired();

            builder.Property(x => x.UploadedByUserId)
                .IsRequired();

            //Relationship
            builder.HasOne(x => x.Incident)
                .WithMany(x => x.IncidentAttachments)
                .HasPrincipalKey(x => x.IncidentNumber)
                .HasForeignKey(x => x.IncidentNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.IncidentAttachments)
                .HasForeignKey(x => x.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

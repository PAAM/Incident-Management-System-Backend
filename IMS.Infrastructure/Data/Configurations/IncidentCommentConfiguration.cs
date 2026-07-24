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
    public class IncidentCommentConfiguration : IEntityTypeConfiguration<IncidentComment>
    {
        public void Configure(EntityTypeBuilder<IncidentComment> builder)
        {
            builder.ToTable("IncidentComments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IncidentNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Comment)
                .HasMaxLength(3000);

            builder.Property(x => x.UserId);

            builder.HasOne(x => x.Incident)
                .WithMany(x=> x.IncidentComments)
                .HasForeignKey(x => x.IncidentNumber)
                .HasPrincipalKey(x => x.IncidentNumber)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);                    
        }
    }
}
